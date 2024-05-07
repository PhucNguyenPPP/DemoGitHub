using DAL.Entities;
using DAL.Entities.Parameters;
using DAL.Util.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.IRepositories
{
    public interface IProductRepository : IGenericRepository<Product>
    {
    }
}
