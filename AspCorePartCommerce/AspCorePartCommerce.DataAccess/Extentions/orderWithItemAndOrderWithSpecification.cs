using AspCoreCommerce.Model.ViewModel;
using AspCorePartCommerce.DataAccess.Specification;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AspCorePartCommerce.DataAccess.Extentions
{
    internal class orderWithItemAndOrderWithSpecification : BaseSpecification<Orders>
    {
        public orderWithItemAndOrderWithSpecification(string email) : base(o=>o.BuyerEmail==email)
        {
            AddInclude(o => o.OrderItems);
            AddInclude(o => o.DelivaryMethod);
            AddOrderByDesciending(o => o.OrderDate);
        }
        public orderWithItemAndOrderWithSpecification(Guid id,string email)
            : base(o =>o.Id==id&& o.BuyerEmail == email)
        {
        }
    }
}
