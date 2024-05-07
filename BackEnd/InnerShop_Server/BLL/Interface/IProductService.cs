using Common.DTO;
using DAL.Entities;
using DAL.Entities.Parameters;

namespace BLL.Interface
{
    public interface IProductService
    {
        Task<PagedList<Product>> GetAllProduct(ProductParameters productParameters);
    }
}
