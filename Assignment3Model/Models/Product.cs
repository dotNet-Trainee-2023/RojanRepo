using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Assignment3Model.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Product Name")]
        [MinLength(3, ErrorMessage = "Min length 3")]
        [MaxLength(20, ErrorMessage = "Min length 20")]
        public string? Name { get; set; }

        [Required]
        [Display(Name = "Price")]
        [Range(1, 1000)]
        public double Price { get; set; }

        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        [ValidateNever]
        public virtual Category? Category { get; set; }

    }
}
