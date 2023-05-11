using AspCoreCommerce.Model;
using AspCorePartCommerce.DataAccess.Data;
using AspCorePartCommerce.Utility;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspCorePartCommerce.DataAccess.DbInilias
{

    public class DbInilizer : IDbInilizer
        {
            private readonly UserManager<ApplicationUser> _userManager;
            private readonly RoleManager<IdentityRole> _roleManager;
            private readonly ApplicationDbContext _db;

            public DbInilizer(
                UserManager<ApplicationUser> userManager,
                RoleManager<IdentityRole> roleManager,
                ApplicationDbContext db)
            {
                _userManager = userManager;
                _roleManager = roleManager;
                _db = db;
            }

            public void intials()
            {
                try
                {
                    if (_db.Database.GetPendingMigrations().Count() > 0)
                    {
                        _db.Database.Migrate();
                    }
                }
                catch (Exception ex)
                {

                }
                if (!_roleManager.RoleExistsAsync(SD.Role_Admin).GetAwaiter().GetResult())
                {
                    _roleManager.CreateAsync(new IdentityRole(SD.Role_User_Indi)).GetAwaiter().GetResult();
                    _roleManager.CreateAsync(new IdentityRole(SD.Role_Admin)).GetAwaiter().GetResult();
                    _roleManager.CreateAsync(new IdentityRole(SD.Role_Employee)).GetAwaiter().GetResult();
                    
                   _userManager.CreateAsync(new ApplicationUser
                    {
                        UserName = "Esraa12",
                       DisplayName = "Esraa12",
                       Email = "admin@AngularDotnetApplicationMaster.com",
                        Name = "Esraa Aseem",
                        PhoneNumber = "011782399",
                        StreetAddress = "sohage,Garge",
                        PostalCode = "34897",
                        City = "sohag"
                    }, "Admin123*").GetAwaiter().GetResult();
                    ApplicationUser user = _db.applicationUsers.FirstOrDefault(u => u.Email == "admin@AngularDotnetApplicationMaster.com");
                    _userManager.AddToRoleAsync(user, SD.Role_Admin).GetAwaiter().GetResult();
                }
                return;
            }
        }


    
}
