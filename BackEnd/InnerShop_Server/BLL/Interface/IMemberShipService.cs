using DAL.Entities;

namespace BLL.Interface
{
    public interface IMemberShipService
    {
        Task<MemberShip> GetBronzeMemberShip(); 
    }
}
