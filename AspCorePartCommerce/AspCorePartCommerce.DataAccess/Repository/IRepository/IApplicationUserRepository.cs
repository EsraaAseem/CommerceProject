using AspCoreCommerce.Model;
using AspCoreCommerce.Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspCorePartCommerce.DataAccess.Repository.IRepository
{
    public interface IApplicationUserRepository:IRepository<ApplicationUser>
    {
        public Task<AddressDto> Update(ApplicationUser applicationUser, AddressDto address);

    }
}
