using BLL.Interface;
using Common.Util.Helpers;
using DTO.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Api_InnerShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        private readonly IEmailService _emailService;
        private readonly IUserService _userService;
        public EmailController(IEmailService emailService, IUserService userService)
        {
            _emailService = emailService;
            _userService = userService;
        }

        /// <summary>
        /// Send OTP email
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        [HttpPost("SendOTPEmail")]
        public ResponseDTO SendOTPEmail(string userID)
        {
            if(!ModelState.IsValid)
            {
                return new ResponseDTO(NotificationMessage.InvalidModel, 400, false);
            }
            var user = _userService.GetUserByUserID(userID);
            if (user == null)
            {
                return new ResponseDTO(ValidationErrorMessage.UserNotFound, 400, false);
            }

            var otpDto = _emailService.GenerateOTP();

            _emailService.SendOTPEmail(user.Email, user.UserName, otpDto.OTPCode);
            return new ResponseDTO(NotificationMessage.SendOTPEmailSuccessfully + user.Email, 200, true, otpDto);
        }

    }
}
