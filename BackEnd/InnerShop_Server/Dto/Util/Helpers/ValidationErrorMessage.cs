namespace Common.Util.Helpers
{
    public static class ValidationErrorMessage
    {
        public const string NullUserName = "Please input username";

        public const string WrongFormatUserName = "Username must have at least 3 characters, at most 30 characters and not contain space";

        public const string UserNameAlreadyExists = "UserName already exists";

        public const string NullFullName = "Please input Full Name";

        public const string WrongFormatFullName = "The format of Full Name is incorrect";

        public const string NullPassword = "Please input password";
        public const string NullToken = "Please input token";
        public const string LogOut = "Log Out Successfully";
        public const string WrongFormatPassword = "Password must have at least 8 characters, at most 20 characters, at least 1 special character and not contain space";
     
        public const string WrongConfirmPassword = "Confirm password is not valid";
        
        public const string UserNotFound = "User not match in the system";
        public const string NullPhoneNumber = "Please input phone number";
        public const string ForgotPassword = "Link will send in your email";
        public const string PasswordUpdate = "Your password have been changed";
       
        public const string WrongFormatPhoneNumber = "The format of phone number is incorrect";

        public const string PhoneNumberAlreadyExists = "Phone number already exists";

        public const string EmailAlreadyExists = "Email already exists";

        public const string NullEmail = "Please input email";

        public const string WrongFormatEmail = "The format of email is incorrect";

        public const string NullBirthday = "Please input birthday";

        public const string WrongFormatBirthday = "The format of birthday is incorrect";

        public const string NullGender = "Please select gender";

        public const string NullAddress = "Please input address";

        public const string WrongFormatAddress = "The format of address is incorrect";

        public const string NullDistrict = "Please select district";

        public const string NullCity = "Please select city";

        public const string LogOutFailed = "Log out error ";

        public const string ResetPassword = "Failed when reset your password";

    }
}
