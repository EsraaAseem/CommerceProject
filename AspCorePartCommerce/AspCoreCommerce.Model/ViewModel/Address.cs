using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AspCoreCommerce.Model.ViewModel
{
    [Owned]
    public class Address
    {
        public Address()
        {
        }
        public Address(string fname,string city,string streetAddress,string pCode,string phone)
        {
            Name = fname;
            City = city;
            StreetAddress = streetAddress;
            PostalCode = pCode;
            PhoneNumber = phone;
            
        }

        [Required]
        public string Name { get; set; }
        public string? City { get; set; }
        [Required]
        public string StreetAddress { get; set; }
        public string? PostalCode { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
    }
}
