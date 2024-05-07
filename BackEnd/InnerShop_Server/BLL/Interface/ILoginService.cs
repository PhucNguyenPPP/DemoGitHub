using Common.DTO;

namespace BLL.Interface
{
    public interface ILoginService
    {
        bool IsUniqueUser(string userName);
        LoginResponseDTO Login(LoginRequestDTO loginRequestDTO);
        TokenDTO RefreshAccessToken(RequestTokenDTO tokenDTO);
        /// <summary>
        /// Add Revoke Refresh token
        /// </summary>
        /// <param name="refreshToken"></param>
        /// <returns></returns>
        TokenDTO Logout(string userid);
    }
}
