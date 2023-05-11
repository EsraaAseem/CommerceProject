using AspCoreCommerce.Model;
using AspCoreCommerce.Model.ViewModel;
using AspCorePartCommerce.DataAccess.Data;
using AspCorePartCommerce.DataAccess.Repository.IRepository;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspCorePartCommerce.DataAccess.Repository
{
    public class UnitOfWork:IUnitOfWork 
    {
            private ApplicationDbContext _db;
        private readonly IBasketRepository _basket;
        private readonly IUnitOfWork _unitOfWork;

        public UnitOfWork(ApplicationDbContext db)
            {
                _db = db;
                brands = new BrandRepository(db);
                categories = new CategoryRepository(db);
                products = new ProductRepository(db);
              reposity = new RepositoryAsyc<Orders>(db);
               ShoppingCart = new ShoppingCartRepository(db);
            applicationUser= new ApplicationUserRepository(db);
            deliveryMethod=new DelieveryRepository(db);
            }
           public IBrandRepository brands { get; private set; }
            public ICategoryRepository categories { get; private set; }
            public IProductRepository products { get; private set; }
            public IRepositoryAysc<Orders> reposity { get; private set; }
            public IShoppingCartRepository ShoppingCart { get; private set; }
            public IApplicationUserRepository applicationUser { get; private set; }
            public IDelieveryRepository deliveryMethod { get; private set; }
           // public IOrderRepository order { get; private set;}

        public void save()
        {
                _db.SaveChanges();
        }
    }

    
}
