using Common.DTO;
using DAL.Entities;
using DTO.DTO;


namespace BLL.Interface
{
    public interface IUserService
    {
        User GetByMonkey();
        ResponseDTO CheckValidationSignUpCustomer(SignUpCustomerDTOResquest model);
        ResponseDTO CheckValidationForgotPassword (ForgotPasswordModelDTO model);
        ResponseDTO ResetPassword(ForgotPasswordModelDTO model);
        ResponseDTO ForgotPassword(string email);
        Task <bool> SignUpCustomer (SignUpCustomerDTOResquest model);
        byte[] GenerateSalt();
        byte[] GenerateHashedPassword(string password, byte[] saltBytes);
        User CheckUserExist(string email);

        Task<Role?> GetCustomerRole();
        User? GetUserByUserID(string userID);
    }
}
