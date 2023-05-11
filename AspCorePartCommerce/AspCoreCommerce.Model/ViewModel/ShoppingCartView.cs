using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspCoreCommerce.Model.ViewModel
{
    public class ShoppingCartView
    {
        public string imageUrl { get; set; }
        public string Title { get; set; }
        public double Price { get; set; }
    }
}
