using AspCoreCommerce.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspCorePartCommerce.DataAccess.Repository.IRepository
{
    public interface ICategoryRepository:IRepository<Category>
    {
        public Task<Category> Update(Guid id, Category categories);
    }
}
