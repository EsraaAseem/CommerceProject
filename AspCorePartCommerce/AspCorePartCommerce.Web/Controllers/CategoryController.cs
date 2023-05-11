using AspCoreCommerce.Model;
using AspCoreCommerce.Model.ViewModel;
using AspCorePartCommerce.DataAccess.Repository.IRepository;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace AspCorePartCommerce.Web.Controllers
{
    [ApiController]
    public class CategoryController :Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        // private readonly IWebHostEnvironment _hostEnvironment;
        private readonly IMapper _mapper;

        public CategoryController(IUnitOfWork unitOfWrok, IMapper mapper)
        {
            _unitOfWork = unitOfWrok;
            this._mapper = mapper;
        }
        [HttpGet]
        [Route("[controller]")]
        public async Task<IActionResult> GetCategories()
        {
            // IEnumerable<StudentsApi.Model.Students> objectcategory =await _unitOfWork.Students.GetAll();
            var Cat = await _unitOfWork.categories.GetAll();
            if (Cat == null || !Cat.Any())
                return NotFound();
            //_mapper.Map<List<Students>>(student)
            return Ok(_mapper.Map<List<CategoryView>>(Cat));
        }

        [HttpGet]
        [Route("[controller]/{stdId:guid}")]
        public async Task<IActionResult> GetStudentAysnc([FromRoute] Guid stdId)
        {
            // var student = await _unitOfWork.Students.GetStudent(stdId);
            var cat = await _unitOfWork.categories.GetFirstOrDefualt(u => u.Id == stdId);
            if (cat == null)
                return NotFound();
            // _unitOfWork.save();
            return Ok(_mapper.Map<CategoryView>(cat));
        }
        [HttpPost]
        //[Authorize]
        [Route("[controller]/Add")]
        public async Task<IActionResult> AddStudent([FromBody] CategoryRequest request)//,IFormFile?file
        {
            var cat = await _unitOfWork.categories.Add(_mapper.Map<Category>(request));
            _unitOfWork.save();
            return Ok(cat);
        }
       [HttpPost]
        //[Authorize]
        [Route("[controller]/{id:guid}")]
        public async Task<IActionResult> UpdateCategory([FromRoute] Guid id,[FromBody] CategoryRequest request)//,IFormFile?file
        {
            var cat = await _unitOfWork.categories.Update(id,_mapper.Map<Category>(request));
            _unitOfWork.save();
            return Ok(cat);
        }



        [HttpPost]
        [Route("[controller]/upload-img")]
        public async Task<IActionResult> Uploadphoto(IFormFile profimgfile)
        {
            if (profimgfile.Length > 0)
            {
                string fileName = Guid.NewGuid().ToString();
                var uploads = Path.Combine(Directory.GetCurrentDirectory(), @"Resources\CatImages");
                var extention = Path.GetExtension(profimgfile.FileName);
                var uploadimg = Path.Combine(uploads, fileName + extention);
                using (var fileStreams = new FileStream(uploadimg, FileMode.Create))
                {
                    await profimgfile.CopyToAsync(fileStreams);
                }
                return Ok(Path.Combine(@"\Resources\CatImages\" + fileName + extention));
                // return Path.Combine(@"\Resources\Images" + fileName + extention);
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
            var obj = await _unitOfWork.categories.GetFirstOrDefualt(u => u.Id == idimg);
            if (obj == null)
            {
                return NotFound();
            }
            if (obj.ImgCatPath != null)
            {
                var oldimg = Path.Combine(Directory.GetCurrentDirectory(), obj.ImgCatPath.TrimStart('\\'));
                if (System.IO.File.Exists(oldimg))
                {
                    System.IO.File.Delete(oldimg);
                }
            }
            return Ok();
        }

    }
    }
