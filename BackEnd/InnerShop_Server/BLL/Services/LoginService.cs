using AutoMapper;
using BLL.Interface;
using Common.DTO;
using Common.Util.Helpers;
using DAL.Entities;
using DAL.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace BLL.Services
{
    public class LoginService : ILoginService
    {
        private readonly IUnitOfWork _unitofWork;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;

        public LoginService(IUnitOfWork unitOfWork, IMapper mapper, IConfiguration configuration)
        {
            _unitofWork = unitOfWork;
            _mapper = mapper;
            _configuration = configuration;
        }

        /// <summary>
        /// this check unique user
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public bool IsUniqueUser(string userName)
        {
            if (!string.IsNullOrEmpty(userName))
            {
                var result = _unitofWork.User.FindAll(x => x.UserName == userName).FirstOrDefault();
                return result != null;
            }
            return false;
        }

        /// <summary>
        /// This is login function ( create accessToken and refreshToken )
        /// </summary>
        /// <param name="loginRequestDTO"></param>
        /// <returns></returns>
        public LoginResponseDTO Login(LoginRequestDTO loginRequestDTO)
        {
            var user = _unitofWork.User.FindAll(x => x.UserName == loginRequestDTO.UserName).Include(u => u.UserRoles).ThenInclude(u => u.Role).FirstOrDefault();
#pragma warning disable CS8603 // Possible null reference return.
            if (user == null) return null;
#pragma warning restore CS8603 // Possible null reference return.

            if (VerifyPasswordHash(loginRequestDTO.Password, user.PasswordHash, user.PasswordSalt))
            {
                string jwtTokenId = null;
                var test = _unitofWork.RefreshToken.FindAll(a => a.UserId == user.UserId && a.IsValid == true).FirstOrDefault();
                string refreshToken = null;
                if (test != null && test.ExpiredAt >= DateTime.Now)
                {
                    refreshToken = test.Refresh_Token;
                    jwtTokenId = _unitofWork.RefreshToken.FindAll(a => a.UserId == user.UserId && a.IsValid == true).FirstOrDefault().JwtId;
                }
                else
                {
                    jwtTokenId = $"JTI{Guid.NewGuid()}";
                    refreshToken = CreateNewRefreshToken(user.UserId, jwtTokenId);
                }
                var accessToken = CreateToken(user, jwtTokenId);
                return new LoginResponseDTO
                {
                    AccessToken = accessToken,
                    User = _mapper.Map<LocalUserDTO>(user),
                    RefreshToken = refreshToken
                };
            };
            return null;
        }

        /// <summary>
        /// This is Create new accessToken with Refresh Token
        /// </summary>
        /// <param name="tokenDTO"></param>
        /// <returns></returns>
        public TokenDTO RefreshAccessToken(RequestTokenDTO tokenDTO)
        {
            // Find an existing refresh token
            var existingRefreshToken = _unitofWork.RefreshToken.FindAll(r => r.Refresh_Token == tokenDTO.RefreshToken).FirstOrDefault();
            if (existingRefreshToken == null)
            {
                return new TokenDTO()
                {
                    Message = MessageErrorInRefreshToken.TokenNotExistInDB
                };
            }

            // Compare data from exixsting refresh and access token provided and if there is any missmatch then consider it as fraud
            var isTokenValid = GetAccessTokenData(tokenDTO.AccessToken, existingRefreshToken.UserId, existingRefreshToken.JwtId);
            if (!isTokenValid)
            {
                existingRefreshToken.IsValid = false;
                _unitofWork.SaveChange();
                return new TokenDTO()
                {
                    Message = MessageErrorInRefreshToken.TokenInvalid
                };
            }

            // Check accessToken expire ?
            var tokenHandler = new JwtSecurityTokenHandler();
            var test = tokenHandler.ReadJwtToken(tokenDTO.AccessToken);
            if (test == null) return new TokenDTO()
            {
                Message = MessageErrorInRefreshToken.ErrorInProcessing
            };

            var accessExpiredDateTime = test.ValidTo;
            // Sử dụng accessExpiredDateTime làm giá trị thời gian hết hạn

            if (accessExpiredDateTime > DateTime.UtcNow)
            {
                return new TokenDTO()
                {
                    Message = MessageErrorInRefreshToken.AccessTokenHasNotExpired
                };
            }
            // When someone tries to use not valid refresh token, fraud possible

            if (!existingRefreshToken.IsValid)
            {
                var chainRecords = _unitofWork.RefreshToken.FindAll(u => u.UserId == existingRefreshToken.UserId && u.JwtId == existingRefreshToken.JwtId).ToList();
                var a = chainRecords;
                foreach (var item in chainRecords)
                {
                    item.IsValid = false;
                }
                _unitofWork.RefreshToken.UpdateRange(chainRecords);
                _unitofWork.SaveChange();
                return new TokenDTO { Message = MessageErrorInRefreshToken.RefreshTokenInvalid };
            }

            // If it just expired then mark as invalid and return empty

            if (existingRefreshToken.ExpiredAt < DateTime.Now)
            {
                existingRefreshToken.IsValid = false;
                _unitofWork.SaveChange();
                return new TokenDTO() { Message = MessageErrorInRefreshToken.RefreshTokenExpired };
            }

            // Replace old refresh with a new one with updated expired date
            var newRefreshToken = ReNewRefreshToken(existingRefreshToken.UserId, existingRefreshToken.JwtId);

            // Revoke existing refresh token
            existingRefreshToken.IsValid = false;
            _unitofWork.SaveChange();
            // Generate new access token
            var user = _unitofWork.User.FindAll(a => a.UserId == existingRefreshToken.UserId).Include(u => u.UserRoles).ThenInclude(u => u.Role).FirstOrDefault();
            if (user == null)
            {
                return new TokenDTO();
            }
            var newAccessToken = CreateToken(user, existingRefreshToken.JwtId);
            return new TokenDTO()
            {
                AccessToken = newAccessToken,
                RefreshToken = newRefreshToken,
                Message = MessageErrorInRefreshToken.Successfully
            };
        }

        /// <summary>
        /// This is CreateToken function to create new token when login successfull
        /// </summary>
        /// <param name="user"></param>
        /// <param name="jwtId"></param>
        /// <returns></returns>
        private string CreateToken(User user, string jwtId)
        {
            var test = user.UserRoles.ToList();
#pragma warning disable CS8602 // Dereference of a possibly null reference.
            var roleName = user.UserRoles.FirstOrDefault(u => u.UserId == user.UserId).Role.RoleName;
#pragma warning restore CS8602 // Dereference of a possibly null reference.


            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.FullName.ToString()),
                new Claim(ClaimTypes.Role, roleName.ToString()),
                new Claim(JwtRegisteredClaimNames.Jti, jwtId),
                new Claim(JwtRegisteredClaimNames.Sub, user.UserId.ToString()),
                new Claim(JwtRegisteredClaimNames.Exp, DateTime.Now.AddSeconds(45).ToString(), ClaimValueTypes.Integer64)
            };
            var key = _configuration.GetSection("ApiSetting")["Secret"];
#pragma warning disable CS8604 // Possible null reference argument.
            var securityKey = new SymmetricSecurityKey(System.Text.Encoding.ASCII.GetBytes(key));
#pragma warning restore CS8604 // Possible null reference argument.
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
               claims: claims,
               expires: DateTime.Now.AddSeconds(45),
               signingCredentials: credentials
           );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        /// <summary>
        /// This is Verify Password because password is hash and salt
        /// </summary>
        /// <param name="password"></param>
        /// <param name="passwordHash"></param>
        /// <param name="passwordSalt"></param>
        /// <returns></returns>
        private bool VerifyPasswordHash(string password, byte[] storedHash, byte[] salt)
        {
            // Compute the hash of the provided password using the provided salt
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
            byte[] passwordWithSaltBytes = new byte[passwordBytes.Length + salt.Length];

            for (int i = 0; i < passwordBytes.Length; i++)
            {
                passwordWithSaltBytes[i] = passwordBytes[i];
            }

            for (int i = 0; i < salt.Length; i++)
            {
                passwordWithSaltBytes[passwordBytes.Length + i] = salt[i];
            }

            using (var cryptoProvider = SHA512.Create())
            {
                byte[] hashedPassword = cryptoProvider.ComputeHash(passwordWithSaltBytes);

                // Compare the computed hash with the stored hash
                return CompareByteArrays(hashedPassword, storedHash);
            }
        }

        private bool CompareByteArrays(byte[] array1, byte[] array2)
        {
            if (array1 == null || array2 == null || array1.Length != array2.Length)
            {
                return false;
            }

            for (int i = 0; i < array1.Length; i++)
            {
                if (array1[i] != array2[i])
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// This is to read the data (claim) in Token
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="expectedUserId"></param>
        /// <param name="expectedTokenId"></param>
        /// <returns></returns>
        private bool GetAccessTokenData(string accessToken, Guid expectedUserId, string expectedTokenId)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var jwt = tokenHandler.ReadJwtToken(accessToken);
                var jwtId = jwt.Claims.FirstOrDefault(a => a.Type == JwtRegisteredClaimNames.Jti)?.Value;
                var userId = jwt.Claims.FirstOrDefault(a => a.Type == JwtRegisteredClaimNames.Sub)?.Value;
                userId = userId ?? string.Empty;
                return Guid.Parse(userId) == expectedUserId && jwtId == expectedTokenId;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// This is create random token to put into refresh token
        /// </summary>
        /// <returns></returns>
        private string CreateRandomToken()
        {
            return Convert.ToHexString(RandomNumberGenerator.GetBytes(64));
        }

        /// <summary>
        /// This is create new Refresh Token
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="jwtId"></param>
        /// <returns></returns>
        private string CreateNewRefreshToken(Guid userId, string jwtId)
        {
            var time = _unitofWork.RefreshToken.FindAll(a => a.JwtId == jwtId).FirstOrDefault();
            RefreshToken refreshAccessToken = new()
            {
                UserId = userId,
                JwtId = jwtId,
                ExpiredAt = DateTime.Now.AddMinutes(3),
                IsValid = true,
                Refresh_Token = CreateRandomToken(),
            };
            _unitofWork.RefreshToken.Add(refreshAccessToken);
            _unitofWork.SaveChange();
            return refreshAccessToken.Refresh_Token;
        }

        /// <summary>
        /// This function is also create new refresh token but it just create new refresh token not expired time in refresh token ok ?
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="jwtId"></param>
        /// <returns></returns>
        private string ReNewRefreshToken(Guid userId, string jwtId)
        {
            var time = _unitofWork.RefreshToken.FindAll(a => a.JwtId == jwtId).FirstOrDefault();
            RefreshToken refreshAccessToken = new()
            {
                UserId = userId,
                JwtId = jwtId,
                ExpiredAt = time?.ExpiredAt != null ? time.ExpiredAt : DateTime.Now.AddMinutes(3),
                IsValid = true,
                Refresh_Token = CreateRandomToken(),
            };
            _unitofWork.RefreshToken.Add(refreshAccessToken);
            _unitofWork.SaveChange();
            return refreshAccessToken.Refresh_Token;
        }
        /// <summary>
        /// Find token and revoke token
        /// </summary>
        /// <param name="refreshToken"></param>
        /// <returns></returns>
        public TokenDTO Logout(string userId)
        {
            if (string.IsNullOrWhiteSpace(userId))
            {
                return new TokenDTO { Message = ValidationErrorMessage.UserNotFound };
            }

            Guid userIdGuid;
            if (!Guid.TryParse(userId, out userIdGuid))
            {
                return new TokenDTO { Message = ValidationErrorMessage.UserNotFound };
            }

            var user = _unitofWork.User.FindAll(u => u.UserId == userIdGuid);
            if (user == null)
            {
                return new TokenDTO { Message = ValidationErrorMessage.UserNotFound };
            }

            var refreshTokenList = _unitofWork.RefreshToken.GetAll().Where(c => c.UserId == userIdGuid).ToList(); ;

            _unitofWork.RefreshToken.RemoveRange(refreshTokenList);
            _unitofWork.SaveChange();

            return new TokenDTO { Message = ValidationErrorMessage.LogOut };
        }
    }
}

