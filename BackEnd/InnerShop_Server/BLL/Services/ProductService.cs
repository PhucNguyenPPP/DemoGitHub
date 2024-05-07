using BLL.Interface;
using Common.DTO;
using DAL.Entities;
using DAL.Entities.Parameters;
using DAL.UnitOfWork;
using Microsoft.EntityFrameworkCore;

namespace BLL.Services
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<PagedList<Product>> GetAllProduct(ProductParameters productParameters)
        {
            var product =  await _unitOfWork.Product.GetAll().ToListAsync();
            if (product == null)
            {
                throw new Exception("product null");
            }
            return PagedList<Product>.ToPagedList(product, productParameters.PageNumber, productParameters.PageSize);
        }
    }
}
