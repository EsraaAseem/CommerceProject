using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspCoreCommerce.Model.ViewModel
{
    public class orderToReturnDto
    {
        public Guid Id { get; set; }
        public string BuyerEmail { get; set; }
        public DateTimeOffset OrderDate { get; set; } 
        public Address ShippToAddress { get; set; }
        public string DelivaryMethod { get; set; }
        public double shippingPrice { get; set; }
        public List<orderItems> OrderItems { get; set; }
        public double SubTotal { get; set; }
        public string Status { get; set; }
        public double Total { get; set; }
    }
}
