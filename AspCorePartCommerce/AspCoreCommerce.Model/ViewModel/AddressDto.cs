using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspCoreCommerce.Model.ViewModel
{
    public class AddressDto
    {
        [Required]
        public string Name { get; set; }
        public string? City { get; set; }
        [Required]
        public string streetAddress { get; set; }
        public string? PostalCode { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
    }
}
