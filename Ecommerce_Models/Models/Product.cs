using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Identity.Client;
using System.ComponentModel.DataAnnotations.Schema;
using System.Numerics;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Collections.Immutable;

namespace Ecommerce_Models.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string? Color { get; set; }

        [Required]
        public string Brand { get; set; }

        [Required]
        [Display(Name = "Price")]
        [Range(1, 1000000)]
        public double ListPrice { get; set; }


        [Required]
        [Display(Name = " Price for 10+ products")]
        [Range(1, 1000000)]
        public double ListPrice10 { get; set; }

        public int CategoryId { get; set; }

        [ValidateNever]
        [ForeignKey("CategoryId")]
        public Category Category { get; set; }

        [ValidateNever]
        public string ImageUrl { get; set; }


    }


}
