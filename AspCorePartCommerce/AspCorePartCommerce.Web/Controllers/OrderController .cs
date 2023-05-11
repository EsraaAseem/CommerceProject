using AspCoreCommerce.Model;
using AspCoreCommerce.Model.ViewModel;
using AspCorePartCommerce.DataAccess.Extentions;
using AspCorePartCommerce.DataAccess.Repository.IRepository;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StackExchange.Redis;
using System.Reflection;

namespace AspCorePartCommerce.Web.Controllers
{
    [ApiController]
    [Authorize]
    public class OrderController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        // private readonly IWebHostEnvironment _hostEnvironment;
        private readonly IMapper _mapper;
        private readonly IOrderRepository _orderRepo;

        public OrderController(IUnitOfWork unitOfWrok, IMapper mapper, IOrderRepository orderRepo)
        {
            _orderRepo = orderRepo;
            _unitOfWork = unitOfWrok;
            this._mapper = mapper;
        }
        [HttpPost]
        [Route("[controller]")]
        public async Task<ActionResult<Orders>> CreateOrder(orderDto orderDto)
        {
            var email = HttpContext.User.emailfromprinciples();
            var address = _mapper.Map<AddressDto, Address>(orderDto.ShippingToAddress);
            var order = await _orderRepo.CratedOrderAsyc(email, orderDto.DelivaryMethodId, orderDto.basketId, address);
            if (order == null) { return BadRequest(); }
            return Ok(order);
        }
        
        [HttpGet]
        
        [Route("[controller]")]
        public async Task<ActionResult<IReadOnlyList<orderDto>>> getOrderForUser()
        {
            var email = HttpContext.User.emailfromprinciples();
            var orders=await _orderRepo.GetOrderForUserAsyc(email);
            return Ok(_mapper.Map<IReadOnlyList<Orders>,IReadOnlyList<orderToReturnDto>>(orders));
        }
        [HttpGet] 
        [Route("[controller]/{id}")]
        public async Task<ActionResult<orderToReturnDto>> getOrderByIdForUser(Guid id)//orderToReturnDto
        {
            var email = HttpContext.User.emailfromprinciples();
            var order = await _orderRepo.getOrderByIdAsyc(id,email);
            if(order == null) { return BadRequest(); }
            return Ok(_mapper.Map<orderToReturnDto>(order));
        }
        [HttpGet]
        [Route("[controller]/GetDelievery")]
        public async Task<IActionResult> GetDelievery()
        {
            // IEnumerable<StudentsApi.Model.Students> objectcategory =await _unitOfWork.Students.GetAll();
            var delievery = await _unitOfWork.deliveryMethod.GetAll();
            if (delievery == null || !delievery.Any())
                return NotFound();
            //_mapper.Map<List<Students>>(student)
            return Ok(_mapper.Map<List<Delievery>>(delievery));
        }
      
        [HttpPost]
        [Route("[controller]/SetDelievery")]
        public async Task<IActionResult> SetDelievery(Delievery delivary)
        {
            var delievery = await _unitOfWork.deliveryMethod.Add(_mapper.Map<DelivaryMethod>(delivary));
            _unitOfWork.save();
            return Ok(delievery);
        }


    }
}
