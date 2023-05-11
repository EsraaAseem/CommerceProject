using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace AspCoreCommerce.Model.ViewModel
{
    public class shoppingCartrequest
    {
        [Key]
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public string? ApplicationUserId { get; set; }
        [Range(1, 1000, ErrorMessage = "out of range")]
        [ValidateNever]
        public ApplicationUser applicationUser { get; set; }
        [ValidateNever]
        public Product product { get; set; }
        public int Count { get; set; }
        public double Price { get; set; }
    }
}
