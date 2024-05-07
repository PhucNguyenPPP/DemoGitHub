
using Common.DTO;

namespace BLL.Interface
{
    public interface IEmailService
    {
        OtpCodeDTO GenerateOTP();
        void SendOTPEmail(string userEmail, string userName, string otpCode);
    }
}
