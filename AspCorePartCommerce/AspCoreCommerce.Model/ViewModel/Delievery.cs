using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspCoreCommerce.Model.ViewModel
{
    public class Delievery
    {
        public Guid Id { get; set; }
        public string shortTime { get; set; }
        public string DelivaryTime { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
    }
}
