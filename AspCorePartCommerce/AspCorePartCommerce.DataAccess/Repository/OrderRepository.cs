using AspCoreCommerce.Model;
using AspCoreCommerce.Model.ViewModel;
using AspCorePartCommerce.DataAccess.Data;
using AspCorePartCommerce.DataAccess.Extentions;
using AspCorePartCommerce.DataAccess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspCorePartCommerce.DataAccess.Repository
{
    public class OrderRepository:IOrderRepository
    {
        // ApplicationDbContext _db;
        private readonly IBasketRepository _basket;
        private readonly IUnitOfWork _unitOfWork;
       // private readonly IRepositoryAysc<Order> _repositoryAysc;
        //private readonly IRepositoryAysc<DelivaryMethod> _repositoryDelieveryAysc;

        public OrderRepository(ApplicationDbContext db ,IBasketRepository basket,IUnitOfWork unitOfWork)//, IRepositoryAysc<Order> repositoryAysc
        {
            this._basket = basket;
            this._unitOfWork = unitOfWork;
           // _repositoryAysc = repositoryAysc;
          //  _repositoryDelieveryAysc = repositoryDelievery;
        }

        public async Task<Orders> CratedOrderAsyc(string BuryEmail, Guid DelivaryMethodId, string basketId, Address shippingAddress)
        {
            var basket=await _basket.GetBasketAsync(basketId);
            var Items = new List<orderItems>();
            foreach(var item in basket.items )
            {
                var productitem= await _unitOfWork.products.GetFirstOrDefualt(i=>i.Id==item.Id);
                var itemorderd = new ProductItemOrdered(productitem.Id, productitem.Title, productitem.ImageUrl);
                var orderITem = new orderItems(itemorderd, productitem.Price, item.Count);
                Items.Add(orderITem);
            };
            var delieveryMethod = await _unitOfWork.deliveryMethod.GetFirstOrDefualt(i => i.Id == DelivaryMethodId);
            var subTotal = Items.Sum(item => item.Price * item.Quentity);
            var order=new Orders(BuryEmail,shippingAddress,delieveryMethod,Items,subTotal);
            var result=_unitOfWork.reposity.Add(order);
         //   if (result == null) return null;
           _unitOfWork.save();
           _basket.DeleteBasketAsyc(basketId);
            return order;
        }

       

      public async Task<Orders> getOrderByIdAsyc(Guid id, string buryEmail)
        {
            var spec = new orderWithItemAndOrderWithSpecification(id,buryEmail);
            return await _unitOfWork.reposity.GetEntityWithSpac(spec);
        }

        public async Task<IReadOnlyList<Orders>> GetOrderForUserAsyc(string BuryEmail)
        {
            var spec = new orderWithItemAndOrderWithSpecification(BuryEmail);
           return await _unitOfWork.reposity.ListAysc(spec);

        }
        public void save()
        {
            _unitOfWork.save();
        }
    }
}
