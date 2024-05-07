using DAL.Data;
using DAL.Entities;
using DAL.Entities.Parameters;
using DAL.Repositories.IRepositories;
using DAL.Util.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(InnerContext context) : base(context)
        {
        }
    }
}
