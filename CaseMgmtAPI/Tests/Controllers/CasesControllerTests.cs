using AutoFixture;
using AutoMapper;
using CaseMgmtAPI.Features.Cases.Controllers;
using CaseMgmtAPI.Features.Cases.DTO;
using FakeItEasy;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;

namespace Tests.Controllers
{
    public class CasesControllerTests
    {
        private Fixture fixture;
        //private Mock<IMapper> mapperMock;
        private IMapper _mapper;
        private Mock<IMediator> mediatorMock;
        private Mock<ILogger<CasesController>> loggerMock;
        private CasesController controller;

        public CasesControllerTests()
        {
            fixture = new Fixture();
            //mapperMock = new Mock<IMapper>();
            _mapper = A.Fake<IMapper>();
            mediatorMock = new Mock<IMediator>();
            loggerMock = new Mock<ILogger<CasesController>>();
            //controller = new CasesController(mediatorMock.Object, loggerMock.Object);
        }

        [Fact]
        public async Task Index_Returns_ViewResult()
        {
            //Arrange
            var cases = A.Fake<ICollection<CaseDTO>>();
            var caseList = A.Fake<List<CaseDTO>>();
            A.CallTo(() => _mapper.Map<List<CaseDTO>>(cases)).Returns(caseList);
            var controller = new CasesController(mediatorMock.Object, loggerMock.Object);

            //Act
            var result = await controller.Get();

            //Assert
            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(OkObjectResult));
        }
    }
}
