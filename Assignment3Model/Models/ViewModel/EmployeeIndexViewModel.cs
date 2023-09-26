using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3Model.Models.ViewModel
{
    public class EmployeeIndexViewModel
    {
        public List<Employee> Employees { get; set; } = new List<Employee>();

        public double TotalSalary { get; set; }
    }
}
