using BLL.Interface;
using Common.DTO;
using Common.Util.Helpers;
using DAL.Data;
using DAL.Entities;
using DAL.UnitOfWork;
using DTO.DTO;
using Microsoft.EntityFrameworkCore;
using MimeKit.Cryptography;
using System;
using System.Security.Cryptography;
using System.Text;
using static Org.BouncyCastle.Asn1.Cmp.Challenge;

namespace BLL.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitofWork;
        private readonly IMemberShipService _memberShipService;
        private readonly IValidationHandleService _validationHandle;
        private readonly IEmailService _emailService;

        public UserService(IUnitOfWork unitOfWork,
            IMemberShipService memberShipService,
            IValidationHandleService validationHandle,
            IEmailService emailService)
        {
            _unitofWork = unitOfWork;
            _memberShipService = memberShipService;
            _validationHandle = validationHandle;
            _emailService = emailService;
        }

        public User GetByMonkey()
        {
            var list = _unitofWork.User.FindAll(u => u.UserName == "hung");
#pragma warning disable CS8603 // Possible null reference return.
            return list.Include(u => u.UserRoles).ThenInclude(u => u.Role).FirstOrDefault();
#pragma warning restore CS8603 // Possible null reference return.
        }

        /// <summary>
        /// Check validation for all inputted fields of sign up customer function
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ResponseDTO CheckValidationSignUpCustomer(SignUpCustomerDTOResquest model)
        {
            var userList = _unitofWork.User.GetAll().ToList();

            var checkNullUserName = _validationHandle.CheckNull(model.UserName);
            if (!checkNullUserName)
            {
                var response = new ResponseDTO(ValidationErrorMessage.NullUserName, 400, false);
                return response;
            }

            var checkFormatUserName = _validationHandle.CheckFormatUserName(model.UserName);
            if (!checkFormatUserName)
            {
                var response = new ResponseDTO(ValidationErrorMessage.WrongFormatUserName, 400, false);
                return response;
            }

            var checkUserNameAlreadyExists = _validationHandle.CheckUserNameAlreadyExists(model.UserName, userList);
            if (!checkUserNameAlreadyExists)
            {
                var response = new ResponseDTO(ValidationErrorMessage.UserNameAlreadyExists, 400, false);
                return response;
            }

            var checkNullFullName = _validationHandle.CheckNull(model.FullName);
            if (!checkNullFullName)
            {
                var response = new ResponseDTO(ValidationErrorMessage.NullFullName, 400, false);
                return response;
            }

            var checkFormatFullName = _validationHandle.CheckFormatFullName(model.FullName);
            if (!checkFormatFullName)
            {
                var response = new ResponseDTO(ValidationErrorMessage.WrongFormatFullName, 400, false);
                return response;
            }

            var checkNullPassword = _validationHandle.CheckNull(model.Password);
            if (!checkNullPassword)
            {
                var response = new ResponseDTO(ValidationErrorMessage.NullPassword, 400, false);
                return response;
            }

            var checkFormatPassword = _validationHandle.CheckFormatPassword(model.Password);
            if (!checkFormatPassword)
            {
                var response = new ResponseDTO(ValidationErrorMessage.WrongFormatPassword, 400, false);
                return response;
            }

            var checkConfirmPassword = _validationHandle.CheckConfirmPassword(model.Password, model.ConfirmedPassword);
            if (!checkConfirmPassword)
            {
                var response = new ResponseDTO(ValidationErrorMessage.WrongConfirmPassword, 400, false);
                return response;
            }

            var checkNullPhoneNumber = _validationHandle.CheckNull(model.Phone);
            if (!checkNullPhoneNumber)
            {
                var response = new ResponseDTO(ValidationErrorMessage.NullPhoneNumber, 400, false);
                return response;
            }

            var checkFormatPhoneNumber = _validationHandle.CheckFormatPhoneNumber(model.Phone);
            if (!checkFormatPhoneNumber)
            {
                var response = new ResponseDTO(ValidationErrorMessage.WrongFormatPhoneNumber, 400, false);
                return response;
            }

            var checkPhoneAlreadyExists = _validationHandle.CheckPhoneNumberAlreadyExists(model.Phone, userList);
            if (!checkPhoneAlreadyExists)
            {
                var response = new ResponseDTO(ValidationErrorMessage.PhoneNumberAlreadyExists, 400, false);
                return response;
            }

            var checkNullEmail = _validationHandle.CheckNull(model.Email);
            if (!checkNullEmail)
            {
                var response = new ResponseDTO(ValidationErrorMessage.NullEmail, 400, false);
                return response;
            }

            var checkFormatEmail = _validationHandle.CheckFormatEmail(model.Email);
            if (!checkFormatEmail)
            {
                var response = new ResponseDTO(ValidationErrorMessage.WrongFormatEmail, 400, false);
                return response;
            }

            var checkEmailAlreadyExists = _validationHandle.CheckEmailAlreadyExists(model.Email, userList);
            if (!checkEmailAlreadyExists)
            {
                var response = new ResponseDTO(ValidationErrorMessage.EmailAlreadyExists, 400, false);
                return response;
            }

            var checkNullBirthday = _validationHandle.CheckNull(model.Birthday);
            if (!checkNullBirthday)
            {
                var response = new ResponseDTO(ValidationErrorMessage.NullBirthday, 400, false);
                return response;
            }

            var checkFormatBirthday = _validationHandle.CheckFormatBirthday(model.Birthday);
            if (!checkFormatBirthday)
            {
                var response = new ResponseDTO(ValidationErrorMessage.WrongFormatBirthday, 400, false);
                return response;
            }

            var checkNullGender = _validationHandle.CheckNull(model.Gender);
            if (!checkNullGender)
            {
                var response = new ResponseDTO(ValidationErrorMessage.NullGender, 400, false);
                return response;
            }

            var checkNullAdress = _validationHandle.CheckNull(model.Address);
            if (!checkNullAdress)
            {
                var response = new ResponseDTO(ValidationErrorMessage.NullAddress, 400, false);
                return response;
            }

            var checkFormatAdrress = _validationHandle.CheckFormatAddress(model.Address);
            if (!checkFormatAdrress)
            {
                var response = new ResponseDTO(ValidationErrorMessage.WrongFormatAddress, 400, false);
                return response;
            }

            var checkNullDistrict = _validationHandle.CheckNull(model.District);
            if (!checkNullDistrict)
            {
                var response = new ResponseDTO(ValidationErrorMessage.NullDistrict, 400, false);
                return response;
            }

            var checkNullCity = _validationHandle.CheckNull(model.City);
            if (!checkNullCity)
            {
                var response = new ResponseDTO(ValidationErrorMessage.NullCity, 400, false);
                return response;
            }

            var successfulResponse = new ResponseDTO("Check Validation Successfully", 200, true);
            return successfulResponse;
        }

        /// <summary>
        /// Add new Customer into DB Service
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<bool> SignUpCustomer(SignUpCustomerDTOResquest model)
        {
            var result = false;
            var saltBytes = GenerateSalt();
            var passwordHashedBytes = GenerateHashedPassword(model.Password, saltBytes);
            var memberShipBronze = await _memberShipService.GetBronzeMemberShip();

            var checkBirthDay = DateTime.TryParse(model.Birthday, out DateTime birthday);
            if (checkBirthDay)
            {
                var newuser = new User
                {
                    UserId = Guid.NewGuid(),
                    UserName = model.UserName,
                    Phone = model.Phone,
                    PasswordSalt = saltBytes,
                    PasswordHash = passwordHashedBytes,
                    Email = model.Email,
                    FullName = model.FullName,
                    Birthday = birthday,
                    Gender = model.Gender,
                    Address = model.Address,
                    District = model.District,
                    City = model.City,
                    MoneySpent = 0,
                    Status = true,
                    MemberShipId = memberShipBronze.MemberShipId,
                };

                var customerRole = await GetCustomerRole();
                var userRole = new UserRole
                {
                    UserId = newuser.UserId,
                    RoleId = customerRole.RoleId
                };

                await _unitofWork.User.AddAsync(newuser);
                await _unitofWork.UserRole.AddAsync(userRole);
                result = await _unitofWork.SaveChangeAsync();
                return result;
            }
            return result;
        }

        /// <summary>
        /// Generate random salt service
        /// </summary>
        /// <returns></returns>
        public byte[] GenerateSalt()
        {
            byte[] saltBytes = new byte[32];
            var rng = RandomNumberGenerator.Create();
            rng.GetNonZeroBytes(saltBytes);
            return saltBytes;
        }

        /// <summary>
        /// Hash string of password and salt service
        /// </summary>
        /// <param name="password"></param>
        /// <param name="saltBytes"></param>
        /// <returns></returns>
        public byte[] GenerateHashedPassword(string password, byte[] saltBytes)
        {
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
            byte[] passwordWithSaltBytes = new byte[passwordBytes.Length + saltBytes.Length];

            for (int i = 0; i < passwordBytes.Length; i++)
            {
                passwordWithSaltBytes[i] = passwordBytes[i];
            }

            for (int i = 0; i < saltBytes.Length; i++)
            {
                passwordWithSaltBytes[passwordBytes.Length + i] = saltBytes[i];
            }

            var cryptoProvider = SHA512.Create();
            byte[] hashedBytes = cryptoProvider.ComputeHash(passwordWithSaltBytes);

            return hashedBytes;
        }

        public ResponseDTO CheckValidationForgotPassword(ForgotPasswordModelDTO model)
        {
            var userList = _unitofWork.User.GetAll().ToList();


            var checkNullPassword = _validationHandle.CheckNull(model.Password);
            if (!checkNullPassword)
            {
                var response = new ResponseDTO(ValidationErrorMessage.NullPassword, 400, false);
                return response;
            }
            var checkToken = _validationHandle.CheckNullToken(model.OTP);
            if (!checkToken)
            {
                var response = new ResponseDTO(ValidationErrorMessage.NullToken, 400, false);
            }

            var checkFormatPassword = _validationHandle.CheckFormatPassword(model.Password);
            if (!checkFormatPassword)
            {
                var response = new ResponseDTO(ValidationErrorMessage.WrongFormatPassword, 400, false);
                return response;
            }

            var successfulResponse = new ResponseDTO("Check Validation Successfully", 200, true);
            return successfulResponse;
        }

        public ResponseDTO ResetPassword(ForgotPasswordModelDTO model)
        {
            var saltBytes = GenerateSalt();
            var passwordHashedBytes = GenerateHashedPassword(model.Password, saltBytes);
            var user = _unitofWork.User.FindAll(u => u.ResetPassToken == model.OTP).FirstOrDefault();
            if (user == null)
            {
                return new ResponseDTO(ValidationErrorMessage.UserNotFound, 400, false);
            }

            var checkValidation = CheckValidationForgotPassword(model);
            if (!checkValidation.IsSuccess)
            {
                return checkValidation;
            }

            user.PasswordHash = passwordHashedBytes;
            user.PasswordSalt = saltBytes;
            user.ResetPassToken = null;


            _unitofWork.SaveChangeAsync();

            return new ResponseDTO(ValidationErrorMessage.PasswordUpdate, 200, true);
        }

        public ResponseDTO ForgotPassword(string email)
        {
            var user = _unitofWork.User.FindAll(u => u.Email == email).FirstOrDefault();
            if (user == null)
            {
                return new ResponseDTO(ValidationErrorMessage.UserNotFound, 400, false);
            }

            var otp = _emailService.GenerateOTP();
            user.ResetPassToken = otp.OTPCode;


            _unitofWork.SaveChange();

            return new ResponseDTO(ValidationErrorMessage.ForgotPassword, 200, true);
        }
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

        public User CheckUserExist(string email)
        {
            var result = _unitofWork.User.FindAll(x => x.Email == email).FirstOrDefault();
            return result != null ? result : null;


        }

        /// <summary>
        /// Get Role has RoleName is customer service
        /// </summary>
        /// <returns></returns>
        public async Task<Role?> GetCustomerRole()
        {
            var result = await _unitofWork.Role.GetAll()
                .Where(c => c.RoleName.ToLower().Equals("customer")).FirstOrDefaultAsync();
            return result;
        }

        /// <summary>
        /// Get User By userId
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public User? GetUserByUserID(string userID)
        {
            var checkUserID = Guid.TryParse(userID, out var guidUserID);
            var user = _unitofWork.User.GetAll().FirstOrDefault(c => c.UserId == guidUserID);
            return user;
        }
    }
}
