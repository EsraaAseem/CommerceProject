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
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private ApplicationDbContext _db;
        public ProductRepository(ApplicationDbContext db) : base(db)
        {
            this._db = db;
        }
        public async Task<Product> Update(Guid id, Product product)
        {
            var obj = _db.Products.FirstOrDefault(u => u.Id == id);
            if (obj != null)
            {
                obj.Title = product.Title;
                obj.Description= product.Description;
                obj.Price = product.Price;
                obj.ListPrice = product.ListPrice;
                obj.CategoryId = product.CategoryId;
                obj.BrandId = product.BrandId;
                if (product.ImageUrl != null)
                {
                    obj.ImageUrl = product.ImageUrl;
                }
                return obj;
            }
            return null;
        }
    }
}
