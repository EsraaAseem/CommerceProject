using AspCoreCommerce.Model;
using AspCoreCommerce.Model.ViewModel;
using Microsoft.EntityFrameworkCore.Metadata;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspCorePartCommerce.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork
    {
        IBrandRepository brands { get; }
        ICategoryRepository categories { get; }
        IProductRepository products { get; }
        IShoppingCartRepository ShoppingCart { get; }
       // IOrderRepository order { get; }
        IApplicationUserRepository applicationUser { get; }
        IDelieveryRepository deliveryMethod { get; }
        IRepositoryAysc<Orders> reposity { get; }           
        public void save();
    }
}
