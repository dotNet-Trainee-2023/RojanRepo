using Assignment3.Services.EmployeeService;
using Assignment3Data.Data;
using Assignment3Model.Models;
using Assignment3Model.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Assignment3.Controllers
{
    public class EmployeeController : Controller
    {
        /*  private readonly AppDbContext _context;*/
        private readonly IEmployeeService _employeeService;
        private static List<Employee> _employees = new List<Employee>
        {
            new Employee { Id = 1, Name = "Abhash", Department = "HR" },
            new Employee { Id = 2, Name = "Saksham", Department = "Operations" },
            new Employee { Id = 3, Name = "Anjish", Department = "R&D" }
        };

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var employees = _employeeService.GetEmployees();

            var viewmodel = new EmployeeIndexViewModel();
            viewmodel.Employees = employees;
            viewmodel.TotalSalary = employees.Sum(x => x.Salary);

            ViewBag.TotalEmployees = employees.Count();
            ViewBag.Positions = employees.Select(x => x.Position);
            ViewBag.Employees = employees;

            ViewData["Employee"] = employees.FirstOrDefault(x => x.Name!.Contains("Abhash"));
            ViewBag.Employee = TempData["Employee"];

            TempData["Test"] = "Test";

            //return Ok();
            //return BadRequest();
            //return NotFound();
            //return NoContent();
            //return StatusCode(StatusCodes.Status500InternalServerError);
            return View(viewmodel);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var dept = new List<string> { "HR", "Operations", "R&D" };

            var dropdown = new SelectList(dept.Select(x => new { Id = x, Name = x }), "Id", "Name");

            var vm = new EmployeeCreateViewModel();
            vm.DropdownDepartments = dropdown;


            return View(vm);
        }

        [HttpPost]
        public IActionResult Create(Employee employee)
        {
            if (!ModelState.IsValid)
            {
                return View(employee);
            }

            _employeeService.CreateEmployee(employee);
            TempData["Employee"] = "Abhash";

            return RedirectToAction("Index", "Employee");
        }

        public IActionResult Edit(int index)
        {
            var employee = _employeeService.GetEmployee(index);
            return View(employee);
        }

        [HttpPost]
        public IActionResult Edit(Employee model)
        {
            if (!ModelState.IsValid)
            {
            
                return View(model);
            }

            _employeeService.UpdateEmployee(model);

            return RedirectToAction("Index", "Employee");
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            _employeeService.DeleteEmployee(id);

            return RedirectToAction("Index");
        }
    }
}
