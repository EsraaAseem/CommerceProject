using AspCoreCommerce.Model.ViewModel;
using AspCorePartCommerce.DataAccess.Specification;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AspCorePartCommerce.DataAccess.Repository.IRepository
{
    public interface IRepositoryAysc<T> where T : BaseEntity
    {
       Task<T> GetEntityWithSpac(ISpecification<T> spac);
        Task<IReadOnlyList<T>> ListAysc(ISpecification<T> spac);
        Task<IReadOnlyList<T>> ListAllAysc();
        Task<T> Add(T identity);
    }
}
