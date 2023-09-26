using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3Model.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required property.")]
        [Display(Name = "Employee Name")]
        public string? Name { get; set; } = string.Empty;

        [Required]
        public string Department { get; set; } = "";

        [Required]
        public double Salary { get; set; }

        [Required]
        [MinLength(10, ErrorMessage = "Min length 10")]
        //[EmailAddress]
        public string Position { get; set; } = string.Empty;
    }
}
