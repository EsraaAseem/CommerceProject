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
    public class ShoppingCartRepository : Repository<ShoppingCart>, IShoppingCartRepository
    {
        public ShoppingCartRepository(ApplicationDbContext db) : base(db)
        {
        }
        public int Increase(ShoppingCart cart, int Count)
        {
            cart.Count += Count;
            return cart.Count;
        }
        public int Decrease(ShoppingCart cart, int Count)
        {
            cart.Count -= Count;
            return cart.Count;
        }

    }
}
