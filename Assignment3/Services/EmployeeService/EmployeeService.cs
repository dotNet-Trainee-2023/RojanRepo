using Assignment3Data.Data;
using Assignment3Model.Models;

namespace Assignment3.Services.EmployeeService
{
    public class EmployeeService:IEmployeeService
    {
        private readonly AppDbContext _context;

        public EmployeeService(AppDbContext context)
        {
            _context = context;
        }

        public void CreateEmployee(Employee employee)
        {
            _context.Employees.Add(employee);
            _context.SaveChanges();
        }

        public void DeleteEmployee(int id)
        {
            Employee? employee = _context.Employees.Find(id);
            if (employee != null)
            {
                _context.Employees.Remove(employee);
                _context.SaveChanges();
            }
        }

        public Employee? GetEmployee(int id)
        {
            return _context.Employees.Find(id);
        }

        public List<Employee> GetEmployees()
        {
            return _context.Employees.ToList();
        }

        public void UpdateEmployee(Employee employee)
        {
            var data = _context.Employees.Find(employee.Id);
            if (data != null)
            {
                data.Name = employee.Name;
                data.Department = employee.Department;
                data.Salary = employee.Salary;
                data.Position = employee.Position;

                _context.Employees.Update(data);
                _context.SaveChanges();
            }
        }
    }
}
