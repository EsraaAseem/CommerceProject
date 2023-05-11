using AspCoreCommerce.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspCorePartCommerce.DataAccess.Repository.IRepository
{
    public interface IBrandRepository:IRepository<Brand>
    {
        public Task<Brand> Update(Guid id, Brand brands);

    }
}
