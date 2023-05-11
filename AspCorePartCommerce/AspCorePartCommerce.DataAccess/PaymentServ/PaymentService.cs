using AspCoreCommerce.Model;
using AspCorePartCommerce.DataAccess.Repository;
using AspCorePartCommerce.DataAccess.Repository.IRepository;
using Microsoft.Extensions.Configuration;
using Stripe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspCorePartCommerce.DataAccess.PaymentServ
{
        public class PaymentService : IPaymentService
    {
        private readonly IBasketRepository _basketRepository; 
        private readonly IUnitOfWork _unitOfWork;


        public PaymentService(IBasketRepository basketRepository,IUnitOfWork unitOfWork)
        { 
            _basketRepository = basketRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<CustomBasket> AddOrUpdatePaymentIntent(string basketid)
        {
           // StripeConfiguration.ApiKey = _config["StripeSettings:SecretKey"];
            var basket =await _basketRepository.GetBasketAsync(basketid);
            var shippingPrice = 0d;
            if (basket == null)
                return null;
            if(basket.deliveryMethodId.HasValue)
            {
                var delieveryMethod = await _unitOfWork.deliveryMethod.GetFirstOrDefualt(i => i.Id ==basket.deliveryMethodId);
                shippingPrice=delieveryMethod.Price;
            }
            foreach (var item in basket.items)
            {
                var productItem=await _unitOfWork.products.GetFirstOrDefualt(i=>i.Id ==item.Id);
                if(item.Price!=productItem.Price)
                {
                    item.Price = productItem.Price;
                }
            }
            var service = new PaymentIntentService();
            PaymentIntent intent;
            if (string.IsNullOrEmpty(basket.paymentIntenId))
            {
                var option = new PaymentIntentCreateOptions
                {
                    Amount=(long)basket.items.Sum(i=>i.Count*(i.Price*100))+(long)
                    shippingPrice*100,
                    Currency="usd",
                    PaymentMethodTypes=new List<string> { "card" }
                };
                intent=await service.CreateAsync(option);
                basket.paymentIntenId = intent.Id;
                basket.clientSecret = intent.ClientSecret;
            }
            else
            {
                var option = new PaymentIntentUpdateOptions
                {
                    Amount = (long)basket.items.Sum(i => i.Count * (i.Price * 100)) + (long)
                    shippingPrice * 100,
                };
                await service.UpdateAsync(basket.paymentIntenId, option);
            }
            await _basketRepository.UpdateBasketAsyc(basket);
          return basket;
        }
    }
}