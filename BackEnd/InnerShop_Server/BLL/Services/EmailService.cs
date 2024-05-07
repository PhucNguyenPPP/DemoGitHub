using BLL.Interface;
using Common.DTO;
using Common.Util.Helpers;
using Microsoft.Extensions.Configuration;
using System;
using System.Net;
using System.Net.Mail;

namespace BLL.Services
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _configuration;
        private readonly Random random = new Random();
        public EmailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        /// <summary>
        /// Generate OTP code which has 6 characters
        /// </summary>
        /// <returns></returns>
        public OtpCodeDTO GenerateOTP ()
        {
            int otpCode = random.Next(100000, 1000000);
            var otpDto = new OtpCodeDTO
            {
                 OTPCode = otpCode.ToString(),
                 ExpiredTime = DateTime.Now.AddMinutes(15),
            };
            return otpDto;
        }

        /// <summary>
        /// Send otp code
        /// </summary>
        /// <param name="userEmail"></param>
        /// <param name="userName"></param>
        /// <param name="otpCode"></param>
        public void SendOTPEmail(string userEmail, string userName, string otpCode)
        {
            var sendEmail = _configuration.GetSection("SendEmailAccount")["Email"];
            var toEmail = userEmail;
            var subject = "InnerCode E-Commerce: OTP";
            var htmlBody = EmailTemplate.OTPEmailTemplate(userName, otpCode);
            MailMessage mailMessage = new MailMessage(sendEmail, toEmail, subject, htmlBody);
            mailMessage.IsBodyHtml = true;
            
            var smtpServer = _configuration.GetSection("SendEmailAccount")["SmtpServer"];
            int.TryParse(_configuration.GetSection("SendEmailAccount")["Port"], out int port);
            var userNameEmail = _configuration.GetSection("SendEmailAccount")["UserName"];
            var password = _configuration.GetSection("SendEmailAccount")["Password"];

            SmtpClient client = new SmtpClient(smtpServer, port);
            client.UseDefaultCredentials = false;
            client.Credentials = new NetworkCredential(userNameEmail, password);
            client.EnableSsl = true; // Enable SSL/TLS encryption

            client.Send(mailMessage);
        }
    }
}
