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
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private ApplicationDbContext _db;
        public CategoryRepository(ApplicationDbContext db) : base(db)
        {
            this._db = db;
        }
        public async Task<Category> Update(Guid id, Category categories)
        {
            var obj = _db.categories.FirstOrDefault(u => u.Id == id);
            if (obj != null)
            {
                obj.Name = categories.Name;
                obj.Disorder = categories.Disorder;               
                if (categories.ImgCatPath != null)
                {
                    obj.ImgCatPath = categories.ImgCatPath;
                }
                return obj;
            }
            return null;
        }
    }
}
