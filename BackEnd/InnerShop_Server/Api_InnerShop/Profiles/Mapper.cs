using AutoMapper;
using Common.DTO;
using DAL.Entities;

namespace Api_InnerShop.Profiles
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            #region
            CreateMap<User,LocalUserDTO>().ReverseMap();
            #endregion
        }
    }
}
