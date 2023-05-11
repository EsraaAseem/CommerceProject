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
    internal class AddMappingBrandProfile : IMappingAction<BrandRequest, Brand>
    {
        public void Process(BrandRequest source, Brand destination, ResolutionContext context)
        {
            destination.Id = new Guid();
        }
    }
}
