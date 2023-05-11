using AspCoreCommerce.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AspCorePartCommerce.DataAccess.Specification
{
    public class ProWithCatAndBrandSpac : BaseSpecification<Product>
    {
        public ProWithCatAndBrandSpac(Guid? CategoryId, Guid? BrandId) :base(x=>
          (!CategoryId.HasValue || x.CategoryId == CategoryId)&&(!BrandId.HasValue||x.BrandId== BrandId))
        {
            AddInclude(x => x.brand);
            AddInclude(x => x.category);
        }
    }
}
