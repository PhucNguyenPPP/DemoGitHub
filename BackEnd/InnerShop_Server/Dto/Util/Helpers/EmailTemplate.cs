using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Util.Helpers
{
    public static class EmailTemplate
    {
        public static string OTPEmailTemplate(string userName, string otpCode)
        {
            string logoUrl = "https://th.bing.com/th/id/OIP.kIhqHrBdGP_opgoX-u7_jQHaFP?rs=1&pid=ImgDetMain";
            string htmlTemplate = @"<head>    
        <meta content=""text/html; charset=utf-8"" http-equiv=""Content-Type"">
        <title>
            InnerCode E - Commerce: OTP code
        </title>
        <style type=""text/css"">
            html {
                background-color: #FFF;
            }
            body {
                font-size: 120%;
                background-color: wheat;
                border-radius: 5px;
            }
            .logo {
                text-align: center;
                padding: 2% 0;
            }
            .logo img {
                width: 40%;
                height: 35%;
            }
            .title {
                padding: 2% 5%;
                text-align: center; 
                background-color: #FFF; 
                border-radius: 5px 5px 0 0;
            }
            .OTPCode {
                color: darkorange; 
                text-align: center;
            }
            .notice {
                padding: 2% 5%;
                text-align: center;
                background-color: #FFF;
            }
            .footer {
                padding: 2% 5%;
                text-align: center; 
                font-size: 80%; 
                opacity: 0.8; 
            }
            .do-not {
                color: red;
            }
        </style>
    </head>
    <body>
        <table class=""courses-table"">
            <div class=""logo"">
                <img src=""{LOGO_URL}""/>
            </div>
            <div class=""title"">
                <p>Hello {USER_NAME}</p>
                <p>OTP code of your InnerCode E-Commerce account is </p>
            </div>
            <div class=""OTPCode"">
                <h1>{OTP_CODE}</h1>
            </div>
            <div class=""notice"">
                <p>Expires in 15 minutes. <span class=""do-not""> DO NOT share this code with others, including InnerCode E-Commerce employees.</span>
                </p>
            </div>
            <div class=""footer"">
                <p>This is an automatic email. Please do not reply to this email.</p>
                <p>17th Floor LandMark 81, 208 Nguyen Huu Canh Street, Binh Thanh District, Ho Chi Minh 700000, Vietnam</p>
            </div>
        </table>
    </body>
</html>
";
            htmlTemplate = htmlTemplate.Replace("{OTP_CODE}", otpCode)
                .Replace("{USER_NAME}", userName)
                .Replace("{LOGO_URL}", logoUrl);

            return htmlTemplate;
        }
    }
}
