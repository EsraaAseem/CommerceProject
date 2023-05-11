using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspCoreCommerce.Model.ViewModel
{
    public class ProductRequest
    {
        public string Title { get; set; }
        public string Description { get; set; }
        [Required]
        [Range(1, 2000, ErrorMessage = "Range Must Be Between 1:2000")]

        public double Price { get; set; }
        [Required]
        [Range(1, 2000, ErrorMessage = "Range Must Be Between 1:2000")]

        public double ListPrice { get; set; }
        public Guid CategoryId { get; set; }
        public Guid BrandId { get; set; }
        public string? ImageUrl { get; set; }
    }
}
