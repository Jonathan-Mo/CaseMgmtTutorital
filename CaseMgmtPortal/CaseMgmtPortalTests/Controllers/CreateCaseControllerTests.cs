using CaseMgmtPortal.Controllers;
using CaseMgmtPortal.ViewModels;
using CaseMgmtPortal.Web.Controllers;
using CaseMgmtPortalTests.Mocks;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseMgmtPortalTests.Controllers
{
    public class CreateCaseControllerTests
    {
        [Fact]
        public void Index_Returns_ViewResult()
        {
            //Arrange
            var createCaseController = new CreateCaseController();

            //Act
            var result = createCaseController.Index();

            //Assert
            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public void Index_Creates_New_Case_HttpPost()
        {
            //Arrange
            var mockCase = CaseMocks.GetCase();

            var createCaseController = new CreateCaseController();

            //Act
            var result = createCaseController.Index(mockCase);
            var resultForCheckingRoute = (RedirectToActionResult)createCaseController.Index(mockCase);

            //Assert
            Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Index", resultForCheckingRoute.ActionName);
            Assert.Equal("CreatedCase", resultForCheckingRoute.ControllerName);
        }

        [Fact]
        public void Index_Creates_New_Case_Unsuccssfully_HttpPost()
        {
            //Arrange
            var mockCase = CaseMocks.GetCase();

            var createCaseController = new CreateCaseController();
            createCaseController.ModelState.AddModelError("test", "test");

            //Act
            var result = createCaseController.Index(mockCase);

            //Assert
            Assert.IsType<ViewResult>(result);
        }
    }
}
