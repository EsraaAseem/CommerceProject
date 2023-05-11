using AspCoreCommerce.Model;
using AspCorePartCommerce.DataAccess.Data;
using AspCorePartCommerce.DataAccess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspCorePartCommerce.DataAccess.Repository
{
    public class DelieveryRepository : Repository<DelivaryMethod>, IDelieveryRepository
    {
        public DelieveryRepository(ApplicationDbContext db) : base(db)
        {
        }
    }
}
