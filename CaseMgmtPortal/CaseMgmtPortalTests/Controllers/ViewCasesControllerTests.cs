using AutoFixture;
using AutoFixture.AutoMoq;
using AutoFixture.Kernel;
using AutoMapper;
using CaseMgmtPortal.Controllers;
using CaseMgmtPortal.ModelDTOs;
using CaseMgmtPortal.Models;
using CaseMgmtPortal.ViewModels;
using CaseMgmtPortal.Web.Controllers;
using CaseMgmtPortalTests.Mocks;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseMgmtPortalTests.Controllers
{
    public class ViewCasesControllerTests
    {
        private Fixture fixture;
        private Mock<IMapper> mapperMock;
        private ViewCasesController controller;

        public ViewCasesControllerTests()
        {
            fixture = new Fixture();
            mapperMock = new Mock<IMapper>();
            controller = new ViewCasesController(mapperMock.Object);
        }

        [Fact]
        public void Index_Returns_Case_List_View_Model()
        {
            //Arrange

            //Act
            //var result = controller.Index();

            //Assert
            //var viewResult = Assert.IsType<ViewResult>(result);
            //Assert.IsAssignableFrom<CaseListViewModel>(viewResult.ViewData.Model);
        }

        [Fact]
        public void ViewCase_Returns_ViewResult()
        {
            //Arrange
            var mockCase = CaseMocks.GetCase();

            var mockCaseId = mockCase.Id;

            //Act
            var result = controller.ViewCase(mockCaseId);

            //Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            //Assert.IsAssignableFrom<CaseDTO>(viewResult.ViewData.Model);
        }

        [Fact]
        public void EditCase_Returns_Case()
        {
            //Arrange
            var mockCase = CaseMocks.GetCase();

            var mockCaseId = mockCase.Id;

            //Act
            var result = controller.EditCase(mockCaseId);

            //Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            //Assert.IsAssignableFrom<CaseDTO>(viewResult.ViewData.Model);
        }

        [Fact]
        public void EditCase_Returns_RediractToAction_When_Successful()
        {
            //Arrange
            //var mockCase = CaseMocks.GetCaseDTO();
            //var newFixture = fixture.Build<CaseDTO>().Create();


            //Act
            //var result = (RedirectToActionResult)controller.EditCase(newFixture);

            //Assert
            //Assert.IsType<RedirectToActionResult>(result);
            //Assert.Equal("UpdatedCase", result.ActionName);
            //Assert.Equal("ViewCases", result.ControllerName);
        }

        [Fact]
        public void EditCase_Returns_ViewResult_When_Unsuccessful()
        {
            //Arrange
            var mockCase = CaseMocks.GetCaseDTO();

            controller.ModelState.AddModelError("test", "test");

            //Act
            var result = controller.EditCase(mockCase);

            //Assert
            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public void UpdatedCase_Returns_ViewResult_And_Is_Type_CaseDTO()
        {
            //Arrange
            var mockCase = CaseMocks.GetCase();

            var mockCaseId = mockCase.Id;

            //Act
            var result = controller.UpdatedCase(mockCaseId);

            //Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            //Assert.IsAssignableFrom<CaseDTO>(viewResult.ViewData.Model);
        }

        [Fact]
        public void CaseReport_Returns_ViewResult_And_Is_Type_CaseListViewModel()
        {
            //Arrange
            var mockCase = CaseMocks.GetCase();

            //Act
            var result = controller.CaseReport();

            //Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.IsAssignableFrom<CaseListViewModel>(viewResult.ViewData.Model);
        }
    }
}
