using AspCoreCommerce.Model;
using AspCoreCommerce.Model.ViewModel;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspCorePartCommerce.DataAccess.afterMapper
{
    internal class AddMappingAddressProfile : IMappingAction<AddressDto, ApplicationUser>
    {
        public void Process(AddressDto source, ApplicationUser destination, ResolutionContext context)
        {
          //  destination.Id = new Guid();
        }
    }
}
