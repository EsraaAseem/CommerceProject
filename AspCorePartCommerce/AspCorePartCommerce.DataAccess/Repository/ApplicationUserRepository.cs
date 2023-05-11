using AspCoreCommerce.Model;
using AspCoreCommerce.Model.ViewModel;
using AspCorePartCommerce.DataAccess.Data;
using AspCorePartCommerce.DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace AspCorePartCommerce.DataAccess.Repository
{
    public class ApplicationUserRepository : Repository<ApplicationUser>, IApplicationUserRepository
    {
        public ApplicationUserRepository(ApplicationDbContext db) : base(db)
        {
        }

        public async Task<AddressDto> Update(ApplicationUser applicationUser,AddressDto addressDto)
        {
           if(applicationUser!=null)
           {
                applicationUser.Name=addressDto.Name;
                applicationUser.City=addressDto.City;
                applicationUser.StreetAddress = addressDto.streetAddress;
                applicationUser.PhoneNumber=addressDto.PhoneNumber;
                applicationUser.PostalCode=addressDto.PostalCode;
           }
            return addressDto;
        }
    }
}
