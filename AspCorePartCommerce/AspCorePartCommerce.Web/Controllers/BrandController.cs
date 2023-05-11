using AspCoreCommerce.Model;
using AspCoreCommerce.Model.ViewModel;
using AspCorePartCommerce.DataAccess.Repository.IRepository;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace AspCorePartCommerce.Web.Controllers
{
    [ApiController]
    public class BrandController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        // private readonly IWebHostEnvironment _hostEnvironment;
        private readonly IMapper _mapper;

        public BrandController(IUnitOfWork unitOfWrok, IMapper mapper)
        {
            _unitOfWork = unitOfWrok;
            this._mapper = mapper;
        }
        [HttpGet]
        [Route("[controller]")]
        public async Task<IActionResult> GetBrands()
        {
            // IEnumerable<StudentsApi.Model.Students> objectcategory =await _unitOfWork.Students.GetAll();
            var brand = await _unitOfWork.brands.GetAll();
            if (brand == null || !brand.Any())
                return NotFound();
            //_mapper.Map<List<Students>>(student)
            return Ok(_mapper.Map<List<BrandView>>(brand));
        }

        [HttpGet]
        [Route("[controller]/{BrandId:guid}")]
        public async Task<IActionResult> GetBrandAysnc([FromRoute] Guid BrandId)
        {
            // var student = await _unitOfWork.Students.GetStudent(stdId);
            var brand = await _unitOfWork.brands.GetFirstOrDefualt(u => u.Id == BrandId);
            if (brand == null)
                return NotFound();
            // _unitOfWork.save();
            return Ok(_mapper.Map<BrandView>(brand));
        }
        [HttpPost]
        //[Authorize]
        [Route("[controller]/Add")]
        public async Task<IActionResult> AddBrand([FromBody] BrandRequest request)//,IFormFile?file
        {
            var brand = await _unitOfWork.brands.Add(_mapper.Map<Brand>(request));
            _unitOfWork.save();
            return Ok(brand);
        }
       [HttpPost]
        //[Authorize]
        [Route("[controller]/{id:guid}")]
        public async Task<IActionResult> UpdateBrand([FromRoute] Guid id,[FromBody] BrandRequest request)//,IFormFile?file
        {
            var brand = await _unitOfWork.brands.Update(id,_mapper.Map<Brand>(request));
            _unitOfWork.save();
            return Ok(brand);
        }


    }
}
