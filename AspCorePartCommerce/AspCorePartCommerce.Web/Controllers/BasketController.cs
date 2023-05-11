using AspCoreCommerce.Model;
using AspCoreCommerce.Model.ViewModel;
using AspCorePartCommerce.DataAccess.Repository.IRepository;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using System.Reflection;

namespace AspCorePartCommerce.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BasketController:Controller
    {
        private readonly IBasketRepository _basket;
        // private readonly IWebHostEnvironment _hostEnvironment;
        private readonly IMapper _mapper;

        public BasketController(IBasketRepository basket, IMapper mapper)
        {
            _basket = basket;
            this._mapper = mapper;
        }
        [HttpGet]
      //  [Route("[controller]")]
       public async Task<ActionResult<CustomBasket>> GetBasketById(string id)
        {
            var basket = await _basket.GetBasketAsync(id);
            
            return Ok(basket??new CustomBasket(id));
        }
        [HttpGet]
          [Route("/checkId")]
        public async Task<bool> checkId(string id)
        {
            var basket = await _basket.CheckId(id);
            if (basket!=null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        [HttpPost]
        public async Task<ActionResult<CustomBasket>> UpdateBasket(CustomBasket basket)
        {
            var updateBasket = await _basket.UpdateBasketAsyc(basket);
            return Ok(updateBasket);
        }
        [HttpDelete]
        public async Task DeleteBasketAsyc(string id)
        {
            await _basket.DeleteBasketAsyc(id);
        }
    }
}
