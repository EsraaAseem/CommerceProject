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
    public class Repository<T> : IRepository<T> where T:class
        {
            ApplicationDbContext _db;
            public DbSet<T> dbSet;
            public Repository(ApplicationDbContext db)
            {
                this._db = db;
                this.dbSet = _db.Set<T>();
            }


            public async Task<IEnumerable<T>> GetAll(Expression<Func<T, bool>>? filter = null, string? includeProperity = null)
            {
                IQueryable<T> query = dbSet;
                if (filter != null)
                {
                    query =  query.Where(filter);
                }
                if (includeProperity != null)
                {
                    foreach (var properity in includeProperity.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                    {
                        query = query.Include(properity);
                    }
                }
                return await query.ToListAsync();
            }

            public async Task<T> GetFirstOrDefualt(Expression<Func<T, bool>> filter, string? includeProperity = null, bool tracked = true)
            {
                IQueryable<T> query;
                if (tracked == true)
                {
                    query = dbSet;
                }
                else
                {
                    query = dbSet.AsNoTracking();
                }
                if (filter != null)
                {
                    query = query.Where(filter);
                }
                if (includeProperity != null)
                {
                    foreach (var properity in includeProperity.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                    {
                        query = query.Include(properity);
                    }
                }
                return query.FirstOrDefault();
            }
        

        public async Task<T> remove(T identity)
        {
              var del= _db.Remove(identity);
            return del.Entity;
        }

            public void removerange(IEnumerable<T> identity)
            {
                _db.RemoveRange(identity);
            }

            public async Task<T> Add(T identity)
            {
                var student = await _db.AddAsync(identity);
                return student.Entity;
            }
    }

}
