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
    public class HomeControllerTests
    {
        [Fact]
        public void Index_Returns_Case_List_View_Model()
        {
            //Arrange
            var homeController = new HomeController();

            //Act
            var result = homeController.Index();

            //Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var caseListViewModel = Assert.IsAssignableFrom<CaseListViewModel>(viewResult.ViewData.Model);
        }
    }
}
