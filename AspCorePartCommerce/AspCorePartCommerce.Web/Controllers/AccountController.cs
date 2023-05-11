using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
//using Refit;
using Microsoft.AspNetCore.Authorization;
//using Octokit;
using System.IdentityModel.Tokens.Jwt;
using AuthorizeAttribute = Microsoft.AspNetCore.Authorization.AuthorizeAttribute;
using System.Security.Claims;
using AspCorePartCommerce.DataAccess.TokenService;
using AspCoreCommerce.Model.ViewModel;
using AspCoreCommerce.Model;
using AutoMapper;
using AspCorePartCommerce.DataAccess.Repository.IRepository;

namespace StudentsApiWeb.Controllers
{
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ITokenService _tokenService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public AccountController(IHttpContextAccessor httpContextAccessor,
            UserManager<ApplicationUser> userManager,ITokenService tokenService, IUnitOfWork unitOfWork,
           IMapper mapper, SignInManager<ApplicationUser> signInManager, RoleManager<IdentityRole> roleManager)
        {
            _mapper = mapper;
            _userManager = userManager;
            _tokenService = tokenService;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _unitOfWork = unitOfWork;
        }
        [HttpGet]
        [Route("[controller]/getUsers")]

        public async Task<IActionResult> getUsers()
        {
            var user = _userManager.Users.ToList();
            return Ok(user);
        }
        [HttpGet]
        [Route("[controller]/getAddressUsers")]

        public async Task<IActionResult> getAddressUsers()
        {
            var user = await _tokenService.GetUsers();

            return Ok(_mapper.Map<AddressDto>(user));
        }
        [HttpPost]
        [Route("[controller]/updateAddressUsers")]

        public async Task<IActionResult> updateAddressUsers(AddressDto address)
        {
            var user = await _tokenService.GetUsers();
            var resulat = await _unitOfWork.applicationUser.Update(user, address);
            _unitOfWork.save();
             // user = _mapper.Map<AddressDto,ApplicationUser>(address);
           // var resulat = await _userManager.UpdateAsync(user);
            if(resulat != null)
            return Ok(resulat);
            else return BadRequest();
        }
        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] loginUser model)
        {
            if (!ModelState.IsValid)
               return BadRequest(ModelState);

            var result = await _tokenService.LoginAsync(model);

            if (!result.isAuthenticated)
                return BadRequest(result.message);
            if (!string.IsNullOrEmpty(result.RefreshToken))
                SetRefreshTokenInCookie(result.RefreshToken, result.RefreshTokenExpiration);
            return Ok(result);
        }

        [HttpGet("GetCurrentUser")]
        public async Task<IActionResult> GetCurrentUser()
        {
            var user = await _userManager.FindByIdAsync(_httpContextAccessor.HttpContext.User.Identity.Name);
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(user.Email);
        }
        [HttpPost("Register")]
        public async Task<IActionResult> RegisterAsync([FromBody] registerUser model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _tokenService.RegisterAsync(model);

            if (!result.isAuthenticated)
                return BadRequest(result.message);
            SetRefreshTokenInCookie(result.RefreshToken, result.RefreshTokenExpiration);

            return Ok(result);
        }


        [HttpGet("refreshToken")]
        public async Task<IActionResult> RefreshToken()
        {
            var refreshToken = Request.Cookies["refreshToken"];

            var result = await _tokenService.RefreshTokenAsync(refreshToken);

            if (!result.isAuthenticated)
                return BadRequest(result);

            SetRefreshTokenInCookie(result.RefreshToken, result.RefreshTokenExpiration);

            return Ok(result);
        }
        [HttpPost("addRole")]
        public async Task<IActionResult> AddRoleAsync([FromBody] AddRoleModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _tokenService.AddRoleAsync(model);

            if (!string.IsNullOrEmpty(result))
                return BadRequest(result);

            return Ok(model);
        }

        [HttpPost("revokeToken")]
        public async Task<IActionResult> RevokeToken([FromBody] RevokeToken model)
        {
            var token = model.Token ?? Request.Cookies["refreshToken"];

            if (string.IsNullOrEmpty(token))
                return BadRequest("Token is required!");

            var result = await _tokenService.RevokeTokenAsync(token);

            if (!result)
                return BadRequest("Token is invalid!");

            return Ok();
        }
        private void SetRefreshTokenInCookie(string refreshToken, DateTime expires)
        {
            var cookieOptions = new CookieOptions
            {
                HttpOnly = true,
                Expires = expires.ToLocalTime(),
                Secure = true,
                IsEssential = true,
                SameSite = SameSiteMode.None
            };

            Response.Cookies.Append("refreshToken", refreshToken, cookieOptions);
        }
    }
}
      