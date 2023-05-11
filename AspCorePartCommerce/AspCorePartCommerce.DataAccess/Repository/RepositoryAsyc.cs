using AspCoreCommerce.Model.ViewModel;
using AspCorePartCommerce.DataAccess.Data;
using AspCorePartCommerce.DataAccess.Repository.IRepository;
using AspCorePartCommerce.DataAccess.Specification;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AspCorePartCommerce.DataAccess.Repository
{
    public class RepositoryAsyc<T> :IRepositoryAysc<T> where T:BaseEntity
        {
            ApplicationDbContext _db;
            public RepositoryAsyc(ApplicationDbContext db)
            {
                this._db = db;
            }
        public async Task<T> Add(T identity)
        {
            var orderAdd = await _db.AddAsync(identity);
            return orderAdd.Entity;
        }
        public  async Task<T> GetEntityWithSpac(ISpecification<T> spac)
        {
            return await ApplySpecification(spac).FirstOrDefaultAsync();
        }

        public async Task<IReadOnlyList<T>> ListAllAysc()
        {
            return await _db.Set<T>().ToListAsync();
        }

        public async Task<IReadOnlyList<T>> ListAysc(ISpecification<T> spac)
        {
            return await ApplySpecification(spac).ToListAsync();
        }
        private IQueryable<T>ApplySpecification(ISpecification<T> spac)
        {
            return SpecificationAvalutor<T>.GetQuery(_db.Set<T>().AsQueryable(), spac);
        }
    }

}
