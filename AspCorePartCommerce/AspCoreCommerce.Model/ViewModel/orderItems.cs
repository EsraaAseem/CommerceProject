using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspCoreCommerce.Model.ViewModel
{
    public class orderItems: BaseEntity
    {
        
            public orderItems()
            {
            }

            public orderItems(ProductItemOrdered productItemOrdered, double price, int quentity)
            {
                this.ItemOrdered = productItemOrdered;
                Price = price;
                Quentity = quentity;
            }

            public ProductItemOrdered ItemOrdered { get; set; }
            public double Price { get; set; }
            public int Quentity { get; set; }
    }
}
