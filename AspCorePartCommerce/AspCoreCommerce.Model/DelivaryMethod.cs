using AspCoreCommerce.Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspCoreCommerce.Model
{
    public class DelivaryMethod:BaseEntity
    {
        public string shortTime { get; set; }
        public string DelivaryTime { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }

    }
}
