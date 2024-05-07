using BLL.Interface;
using DAL.Entities;
using DAL.UnitOfWork;
using Microsoft.EntityFrameworkCore;

namespace BLL.Services
{
    public class MemberShipService : IMemberShipService
    {
        private readonly IUnitOfWork _unitofWork;
        public MemberShipService(IUnitOfWork unitofWork)
        {
            _unitofWork = unitofWork;
        }

        /// <summary>
        /// Get MemberShip has the Rank is bronze
        /// </summary>
        /// <returns></returns>
        public async Task<MemberShip> GetBronzeMemberShip()
        {
            var result = await _unitofWork.MemberShip.GetAll()
                .Where(c => c.Rank.ToLower().Equals("bronze")).FirstOrDefaultAsync();
            return result;
        }
    }
}
