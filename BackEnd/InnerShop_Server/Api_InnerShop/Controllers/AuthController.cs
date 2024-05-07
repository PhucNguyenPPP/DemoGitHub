using BLL.Interface;
using BLL.Services;
using Common.DTO;
using Common.Util.Helpers;
using DTO.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api_InnerShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ILoginService _loginService;
        private readonly IUserService _userService;

        public AuthController(ILoginService loginService, IUserService userService)
        {
            _loginService = loginService;
            _userService = userService;
        }

        /// <summary>
        /// This is a login endpoint it check user name and password if it true it will create token and refresh token
        /// </summary>
        /// <param name="loginRequestDTO"></param>
        /// <returns></returns>
        [HttpPost("SignIn")]
        public IActionResult Login(LoginRequestDTO loginRequestDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new ResponseDTO(NotificationMessage.InvalidModel, 500, false, ModelState));
            }
            var result = _loginService.Login(loginRequestDTO);
            if (result != null)
            {
                return Ok(new ResponseDTO(NotificationMessage.LoginSuccessfully, 200, true, result));
            }
            return BadRequest(new ResponseDTO(NotificationMessage.LoginFailed, 400, false));
        }

        /// <summary>
        /// This is Refresh token. It means if user want to expand time to use fucntion in app they can use without login again.
        /// </summary>
        /// <param name="tokenDTO"></param>
        /// <returns></returns>
        [HttpPost("RefreshToken")]
        public IActionResult GetNewTokenFromRefreshToken([FromBody] RequestTokenDTO tokenDTO)
        {
            if (ModelState.IsValid)
            {
                var result = _loginService.RefreshAccessToken(tokenDTO);
                if (result == null || string.IsNullOrEmpty(result.AccessToken))
                {
                    return BadRequest(new ResponseDTO(MessageErrorInRefreshToken.CommonError, 400, false, result));
                }
                return Ok(new ResponseDTO(MessageErrorInRefreshToken.Successfully, 201, true, result));
            }
            return BadRequest(new ResponseDTO(NotificationMessage.InvalidModel, 500, false));
        }


        /// <summary>
        /// Sign Up For Customer API
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("SignUpAsCustomer")]
        [ProducesResponseType(201, Type = typeof(ResponseDTO))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> SignUpAsCustomer([FromBody] SignUpCustomerDTOResquest model)
        {
            try
            {
                var checkValidation = _userService.CheckValidationSignUpCustomer(model);
                if (!checkValidation.IsSuccess)
                {
                    return BadRequest(checkValidation);
                }

                var addNewCustomer = await _userService.SignUpCustomer(model);

                if (addNewCustomer)
                {
                    var response = new ResponseDTO(NotificationMessage.SignUpSuccessfully, 201, true);
                    return Ok(response);
                }
                else
                {
                    var response = new ResponseDTO(NotificationMessage.SignUpUnsuccessfully, 400, true);
                    return BadRequest(response);
                }

            }
            catch (Exception ex)
            {
                var response = new ResponseDTO(ex.Message, 400, false);
                return BadRequest(response);
            }
        }

        /// <summary>
        /// Log Out api
        /// </summary>
        /// <param name="logoutDTO"></param>
        /// <returns></returns>
        [HttpPost("LogOut")]
        public IActionResult Logout([FromBody] LogOutDTO logoutDTO)
        {
            if (ModelState.IsValid)
            {
                if (string.IsNullOrWhiteSpace(logoutDTO.UserId))
                {
                    return Ok(new ResponseDTO(ValidationErrorMessage.UserNotFound, 400, false));
                }
                var result = _loginService.Logout(logoutDTO.UserId);

                return Ok(result);
            }
            else
            {
                return Ok(new ResponseDTO(ValidationErrorMessage.LogOutFailed, 400, false));
            }
        }

        /// <summary>
        /// Forgot Password API
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        [HttpPost("forgot-password")]
        public IActionResult ForgotPassword(string email)
        {
            var result = _userService.ForgotPassword(email);
            if (result == null)
            {
                return BadRequest(new ResponseDTO(ValidationErrorMessage.UserNotFound, 400, false));
            }
            return Ok(result);
        }

        /// <summary>
        /// Reset password API
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("reset-password")]
        public IActionResult ResetPassword(ForgotPasswordModelDTO request)
        {
            var validationResult = _userService.CheckValidationForgotPassword(request);

            if (!validationResult.IsSuccess)
            {
                return BadRequest(validationResult);
            }

            var result = _userService.ResetPassword(request);

            if (result.IsSuccess)
            {
                return StatusCode(201, new ResponseDTO(ValidationErrorMessage.PasswordUpdate, 201, true));
            }
            else
            {
                return BadRequest(new ResponseDTO(ValidationErrorMessage.ResetPassword, 400, false));
            }
        }

    }
}
