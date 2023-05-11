using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AspCoreCommerce.Model
{
    public class BasketItem
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public double Price { get; set; }
        public string category { get; set; }
        public int Count { get; set; }
        public string brand { get; set; }
        public string?ImageUrl { get; set; }
    }
}