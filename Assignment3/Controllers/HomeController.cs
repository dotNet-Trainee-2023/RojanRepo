using Assignment3Model.Models;
using Assignment3Model.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Repositories.Contracts;
using System.Diagnostics;

namespace Assignment3.Controllers
{
    public class HomeController : Controller
    {
        
        private readonly IUnitOfWork _uow;
        public HomeController(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<IActionResult> Index()
        {
            var users = await _uow.Users.GetAllUsersWithRole();

            return View(users);
        }

        public async Task<IActionResult> Privacy()
        {
            var roles = await _uow.Roles.GetRoleWithUsers();
            var vm = new PrivacyViewModel()
            {
                Roles = roles
            };

            ViewBag.Test = TempData["Test"];
            return View(vm);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}