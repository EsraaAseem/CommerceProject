using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspCoreCommerce.Model.ViewModel
{
    public class orderItemDto
    {
        public Guid Id { get; set; }
        public string title { get; set; }
        public string ImageUrl { get; set; }
        public double Price { get; set; }
        public int quentity { get; set; }

    }
}
