using AspCoreCommerce.Model;
using AspCoreCommerce.Model.ViewModel;
using AspCorePartCommerce.DataAccess.Repository.IRepository;
using AspCorePartCommerce.DataAccess.TokenService;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace AspCorePartCommerce.Web.Controllers
{
    [ApiController]
   // [Authorize]
    public class ShoppingController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private IHttpContextAccessor _httpContextAccessor;
        private readonly ITokenService _tokenService;

        public ShoppingController(IUnitOfWork unitOfWrok, IMapper mapper, IHttpContextAccessor httpContextAccessor,ITokenService tokenService)
        {
            _unitOfWork = unitOfWrok;
            this._mapper = mapper;
            this._httpContextAccessor = httpContextAccessor;
            this._tokenService=tokenService;
        }
        [HttpGet]
        [Route("[controller]")]
        public async Task<IActionResult> GetShopping()
        {
            //var userId = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            string userId =await this._tokenService.GetUserId();
            if (userId == null)
            {
                return BadRequest();
            }
            /* var claimIdentity = (ClaimsIdentity)User.Identity;
             var claims = claimIdentity.FindFirst(ClaimTypes.NameIdentifier);*/
            var cartlist = await _unitOfWork.ShoppingCart.GetAll(u => u.ApplicationUserId==userId, includeProperity: "product");
            if (cartlist == null || !cartlist.Any())
                return NotFound();
            return Ok(_mapper.Map<List<ShoppingCart>>(cartlist));
        }

        [HttpPost]
        [Route("[controller]")]
        public async Task<IActionResult> Details(shoppingCartEdit shoppingCart)
        {
             
     
         shoppingCart.ApplicationUserId =await this._tokenService.GetUserId();
            ShoppingCart cart = await _unitOfWork.ShoppingCart.GetFirstOrDefualt(u => u.ApplicationUserId == shoppingCart.ApplicationUserId && u.ProductId == shoppingCart.ProductId);
            if (cart == null)
            {
                _unitOfWork.ShoppingCart.Add(_mapper.Map<ShoppingCart>(shoppingCart));
            }
            else
            {
                _unitOfWork.ShoppingCart.Increase(cart, shoppingCart.Count);
                _unitOfWork.save();
            }
            return Ok(shoppingCart);
        }
        [HttpPost]
        [Route("[controller]/increase")]
        public async Task<IActionResult> increase(shoppingCartEdit shoppingCart)
        {

            shoppingCart.ApplicationUserId = await this._tokenService.GetUserId();
            var userId= await this._tokenService.GetUserId();
            ShoppingCart cart = await _unitOfWork.ShoppingCart.GetFirstOrDefualt(u => u.ApplicationUserId == shoppingCart.ApplicationUserId && u.ProductId == shoppingCart.ProductId);
                _unitOfWork.ShoppingCart.Increase(cart,1);
                _unitOfWork.save();
            return Ok(shoppingCart);
        }
        [HttpPost]
        [Route("[controller]/decrase")]
        public async Task<IActionResult> decrase(shoppingCartEdit shoppingCart)
        {

          
            shoppingCart.ApplicationUserId = await this._tokenService.GetUserId();
            ShoppingCart cart = await _unitOfWork.ShoppingCart.GetFirstOrDefualt(u => u.ApplicationUserId == shoppingCart.ApplicationUserId && u.ProductId == shoppingCart.ProductId);
           if(cart.Count<=1)
           {
                _unitOfWork.ShoppingCart.remove(cart);
           }
            else
            {
                _unitOfWork.ShoppingCart.Decrease(cart, 1);
            }
            _unitOfWork.save();
            return Ok(shoppingCart);
        }
        [HttpPost]
        [Route("[controller]/remove")]
        public async Task<IActionResult> remove(shoppingCartEdit shoppingCart)
        {


            shoppingCart.ApplicationUserId = await this._tokenService.GetUserId();
            ShoppingCart cart = await _unitOfWork.ShoppingCart.GetFirstOrDefualt(u => u.ApplicationUserId == shoppingCart.ApplicationUserId && u.ProductId == shoppingCart.ProductId);
            if (cart!=null)
            {
                _unitOfWork.ShoppingCart.remove(cart);
                _unitOfWork.save();
            }
            return Ok(shoppingCart);
        }
    }
}
