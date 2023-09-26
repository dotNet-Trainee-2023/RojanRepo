using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3Model.Models.ViewModel
{
    public class EmployeeCreateViewModel
    {
        public Employee Employee { get; set; } = new Employee();

        public SelectList? DropdownDepartments { get; set; }
    }
}
