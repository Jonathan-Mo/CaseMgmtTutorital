using AutoFixture;
using AutoFixture.AutoMoq;
using AutoFixture.Kernel;
using AutoMapper;
using CaseMgmtPortal.Controllers;
using CaseMgmtPortal.Models;
using CaseMgmtPortal.ViewModels;
using CaseMgmtPortal.Web.Controllers;
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
        [Fact]
        public void Index_Returns_Case_List_View_Model()
        {
            //Arrange
            //var mockMapper = new Mapper<>();
            //mockMapper.SetupAllProperties();

            Case childCase = new Case();
            var data = IMapper<childCase>;
            //var fixture = new Fixture();
            //fixture.Customizations.Add(
            //    new TypeRelay(
            //        typeof(AutoMapper.IMapper),
            //        typeof(ViewCasesController)));
            //var viewCasesController = fixture.Build<ViewCasesController>().Create();

            var viewCasesController = new ViewCasesController(data);

            //Act
            var result = viewCasesController.Index();

            //Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.IsAssignableFrom<CaseListViewModel>(viewResult.ViewData.Model);
        }
    }
}
