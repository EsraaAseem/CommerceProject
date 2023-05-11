using AspCoreCommerce.Model.ViewModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AspCorePartCommerce.DataAccess.Specification
{
    public class SpecificationAvalutor<TEntity>where TEntity: BaseEntity
    {
        public static IQueryable<TEntity> GetQuery(IQueryable<TEntity>inputquery,ISpecification<TEntity>spac)
        {
            var query = inputquery;
            if(spac.Criteria!=null)
            {
                query = query.Where(spac.Criteria);
            }
            query = spac.Includes.Aggregate(query, (current, include) => current.Include(include));
            return query;
        }
    }
}
