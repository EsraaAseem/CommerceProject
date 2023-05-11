using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspCoreCommerce.Model
{
    public class Category
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Range(1, 1000, ErrorMessage = "this out of Range")]
        public int Disorder { get; set; }
        public string? ImgCatPath { get; set; }

    }
}
