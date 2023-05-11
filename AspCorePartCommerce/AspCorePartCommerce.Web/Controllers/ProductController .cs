using AspCoreCommerce.Model;
using AspCoreCommerce.Model.ViewModel;
using AspCorePartCommerce.DataAccess.Repository;
using AspCorePartCommerce.DataAccess.Repository.IRepository;
using AspCorePartCommerce.DataAccess.Specification;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AspCorePartCommerce.Web.Controllers
{
    [ApiController]
    [Authorize]

    public class ProductController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        // private readonly IWebHostEnvironment _hostEnvironment;
        private readonly IMapper _mapper;

        public ProductController(IUnitOfWork unitOfWrok, IMapper mapper)
        {
            _unitOfWork = unitOfWrok;
            this._mapper = mapper;
        }

        [HttpGet]
        [Route("[controller]/filter")]
        public async Task<IActionResult> GetProductsbrId(Guid? CategoryId, Guid? BrandId)
        {
            var product = await _unitOfWork.products.GetAll((u => (!CategoryId.HasValue || u.category.Id == CategoryId)
                && (!BrandId.HasValue || u.brand.Id == BrandId)), includeProperity: "category,brand");
            if (product == null || !product.Any())
                return NotFound();
            return Ok(_mapper.Map<List<ProductView>>(product));
        }
        /*
          [HttpGet]
         [Route("[controller]")]
         public async Task<IActionResult> GetProducts(Guid?CategoryId,Guid?BrandId)
         {
             var spac = new ProWithCatAndBrandSpac(CategoryId,BrandId);
             var product = await _unitOfWork.reposity.ListAysc(spac);
             if (product == null || !product.Any())
                 return NotFound();
             return Ok(_mapper.Map<IReadOnlyList<Product>,IReadOnlyList<ProductView>>(product));
              
         }*/

        [HttpGet]
        [Route("[controller]/{productId:guid}")]
        public async Task<IActionResult> GetProductAysnc([FromRoute] Guid productId)
        {
            var product = await _unitOfWork.products.GetFirstOrDefualt(u => u.Id == productId, includeProperity: "category,brand");
            if (product == null)
                return NotFound();
            return Ok(_mapper.Map<ProductView>(product));
        }
        [HttpPost]
        //[Authorize]
        [Route("[controller]/Add")]
        public async Task<IActionResult> AddProduct([FromBody] ProductRequest request)//,IFormFile?file
        {
            var product = await _unitOfWork.products.Add(_mapper.Map<Product>(request));
            _unitOfWork.save();
            return Ok(product);
        }
       [HttpPost]
        //[Authorize]
        [Route("[controller]/{id:guid}")]
        public async Task<IActionResult> UpdateProduct([FromRoute] Guid id,[FromBody] ProductRequest request)//,IFormFile?file
        {
            var product = await _unitOfWork.products.Update(id,_mapper.Map<Product>(request));
            _unitOfWork.save();
            return Ok(product);
        }
        [HttpPost]
        [Route("[controller]/upload-img")]
        public async Task<IActionResult> Uploadphoto(IFormFile profimgfile)
        {
            if (profimgfile.Length > 0)
            {
                string fileName = Guid.NewGuid().ToString();
                var uploads = Path.Combine(Directory.GetCurrentDirectory(), @"Resources\ProImages");
                var extention = Path.GetExtension(profimgfile.FileName);
                var uploadimg = Path.Combine(uploads, fileName + extention);
                using (var fileStreams = new FileStream(uploadimg, FileMode.Create))
                {
                    await profimgfile.CopyToAsync(fileStreams);
                }
                return Ok(Path.Combine(@"\Resources\ProImages\" + fileName + extention));
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete]
        [Route("[controller]/{idimg:guid}/upload-img")]

        public async Task<IActionResult> DeleteImage([FromRoute] Guid idimg)
        {
            var obj = await _unitOfWork.products.GetFirstOrDefualt(u => u.Id == idimg);
            if (obj == null)
            {
                return NotFound();
            }
            if (obj.ImageUrl != null)
            {
                var oldimg = Path.Combine(Directory.GetCurrentDirectory(), obj.ImageUrl.TrimStart('\\'));
                if (System.IO.File.Exists(oldimg))
                {
                    System.IO.File.Delete(oldimg);
                }
            }
            return Ok();
        }

    }
    }
