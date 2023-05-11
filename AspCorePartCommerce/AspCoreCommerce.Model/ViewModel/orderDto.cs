using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspCoreCommerce.Model.ViewModel
{
    public class orderDto
    {
        public string basketId { get; set; }
        public Guid DelivaryMethodId { get; set; }
        public AddressDto ShippingToAddress { get; set; }
        //public string PaymentIntendId { get; set; } = "Pending";

    }
}
