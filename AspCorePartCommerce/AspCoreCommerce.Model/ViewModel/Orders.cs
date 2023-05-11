using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspCoreCommerce.Model.ViewModel
{
    public class Orders:BaseEntity
    {
        public Orders()
        {
        }

        public Orders(string buyerEmail, Address shippToAddress, DelivaryMethod delivaryMethod, List<orderItems> orderItems, double subTotal)
        {
            BuyerEmail = buyerEmail;
            ShippToAddress = shippToAddress;
            DelivaryMethod = delivaryMethod;
            OrderItems = orderItems;
            SubTotal = subTotal;
        }
        public string BuyerEmail { get; set; }
        public DateTimeOffset OrderDate { get; set; } = DateTimeOffset.Now;
        public Address ShippToAddress { get; set; }
        public DelivaryMethod DelivaryMethod { get; set; }
        public List<orderItems> OrderItems { get; set; }
        public double SubTotal { get; set; }
        public OrderStatus Status { get; set; } = OrderStatus.Pending;
        public string? PaymentIntendId { get; set; }
        public double GetTotal()
        {
            return SubTotal + DelivaryMethod.Price;
        }
        
    }
}
