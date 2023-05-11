using AspCoreCommerce.Model;
using AspCoreCommerce.Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspCorePartCommerce.DataAccess.TokenService
{
    public interface ITokenService
    {
        // string CreateToken(ApplicationUser user);
        Task<userDto> LoginAsync(loginUser Input);
        Task<userDto> RegisterAsync(registerUser Input);
        Task<userDto> GetCurentUser();
        Task<string> AddRoleAsync(AddRoleModel model);
        Task<userDto> RefreshTokenAsync(string token);
        Task<bool> RevokeTokenAsync(string token);
        Task<string> GetUserId();
        Task<ApplicationUser> GetUsers();

    }
}
