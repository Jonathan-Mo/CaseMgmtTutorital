using CaseMgmtPortal.Controllers;
using CaseMgmtPortal.ViewModels;
using CaseMgmtPortal.Web.Controllers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseMgmtPortalTests.Controllers
{
    public class CreatedCaseControllerTests
    {
        [Fact]
        public void Index_Returns_Case_View_Model()
        {
            //Arrange
            var createdCaseController = new CreatedCaseController();

            //Act
            var result = createdCaseController.Index();

            //Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.IsAssignableFrom<CaseViewModel>(viewResult.ViewData.Model);
        }
    }
}
