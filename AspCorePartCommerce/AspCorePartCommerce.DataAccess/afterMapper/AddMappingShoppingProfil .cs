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
    internal class AddMappingShoppingProfile : IMappingAction<shoppingCartEdit, ShoppingCart>
    {
        public void Process(shoppingCartEdit source, ShoppingCart destination, ResolutionContext context)
        {
            destination.Id = new Guid();
        }
    }
}
