using AspCoreCommerce.Model;
using AspCorePartCommerce.DataAccess.Data;
using AspCorePartCommerce.DataAccess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspCorePartCommerce.DataAccess.Repository
{
    public class BrandRepository : Repository<Brand>, IBrandRepository
    {
        private ApplicationDbContext _db;
        public BrandRepository(ApplicationDbContext db) : base(db)
        {
            this._db = db;
        }
        public async Task<Brand> Update(Guid id, Brand brands)
        {
            var obj = _db.Brands.FirstOrDefault(u => u.Id == id);
            if (obj != null)
            {
                obj.Name = brands.Name;
                return obj;
            }
            return null;
        }
    }
}
