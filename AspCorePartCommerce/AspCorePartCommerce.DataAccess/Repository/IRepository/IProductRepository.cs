using AspCoreCommerce.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspCorePartCommerce.DataAccess.Repository.IRepository
{
    public interface IProductRepository:IRepository<Product>
    {
        public Task<Product> Update(Guid id, Product product);

    }
}
