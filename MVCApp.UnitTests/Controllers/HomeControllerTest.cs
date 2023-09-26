using Assignment3.Controllers;
using Assignment3Model.Models;
using Assignment3Model.Models.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using NSubstitute;
using NUnit.Framework;
using Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCApp.UnitTests.Controllers
{
    [TestFixture]
    internal class HomeControllerTest
    {
        private HomeController _controller;
        private IUnitOfWork _unitOfWork;


        [SetUp]
        public void SetUp()
        {
            _unitOfWork = Substitute.For<IUnitOfWork>();

            var httpContext = new DefaultHttpContext();
            var tempData = new TempDataDictionary(httpContext, Substitute.For<ITempDataProvider>());
            tempData["Test"] = "Testing Temp Data";

          /*  _controller = new HomeController(_unitOfWork)
            {
                TempData = tempData
            };*/
        }

        [Test]
        public async Task Index_WhenCalled_ReturnsViewResult()
        {
            var users = new List<User>
            {
                new User { Id = 1, Username = "user1", Email = "user@gmail.com", RoleId = 1 }
            };

            // Arrange
            _unitOfWork.Users.GetAllUsersWithRole().Returns(users);

            // Act
            var result = await _controller.Index();
            var resultView = (ViewResult)result;
            var model = resultView.Model;

            // Assert
            Assert.IsInstanceOf<ViewResult>(result);
            Assert.AreEqual(users, model);
            await _unitOfWork.Users.Received(1).GetAllUsersWithRole();
        }

        [Test]
        public async Task Privacy_WhenCalled_ReturnsViewResult()
        {
            // Arrange
            var users = new List<User>
            {
                new User { Id = 1, Username = "user1", Email = "user@gmail.com", RoleId = 1 }
            };

            var roles = new List<Role>
            {
                new Role { Id = 1, Title = "Admin", Users = users }
            };

            PrivacyViewModel vm = new PrivacyViewModel { Roles = roles };

            _unitOfWork.Roles.GetRoleWithUsers().Returns(roles);

            // Act
            ViewResult result = (ViewResult)(await _controller.Privacy());
            var model = (PrivacyViewModel)result.Model;

            // Assert
            Assert.IsInstanceOf<ViewResult>(result);
            Assert.IsInstanceOf<PrivacyViewModel>(result.Model);
            Assert.AreEqual(vm.Roles, model.Roles);
            await _unitOfWork.Roles.Received(1).GetRoleWithUsers();
        }
    }
}
