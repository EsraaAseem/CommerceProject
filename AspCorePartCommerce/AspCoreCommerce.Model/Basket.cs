using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspCoreCommerce.Model
{
    public class Basket
    {
        public string Id { get; set; }
        public List<BasketItem>items { get; set; }=new List<BasketItem>();
       public Guid? deliveryMethodId { get; set; }
        public string? clientSecret { get; set; }
        public string? paymentIntenId { get; set; }
        public double? shippingPrice { get; set; }
    }
}
