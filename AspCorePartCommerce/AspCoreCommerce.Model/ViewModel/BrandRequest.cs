using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspCoreCommerce.Model.ViewModel
{
    public class BrandRequest
    {
        [Required]
        public string Name { get; set; }
    }
}
