using FluentAssertions;
using FormularApp.Api.Controllers;
using FormularApp.Api.Models;
using FormularApp.Api.Services.Interfaces;
using FormularApp.UnitTests.Fixtures;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace FormularApp.UnitTests.Systems.Controllers
{
    public class TestFansController
    {


        [Fact]
        public async Task Get_OnSuccess_ReturnStatausCode200()
        {
            //Arrage
            var mockFanService = new Mock<IFanService>();
            mockFanService.Setup(service => service.GetAllFans())
                .ReturnsAsync(FansFixtures.GetFans());

            var fansController = new FansController(mockFanService.Object);

            //Act
            var result = (OkObjectResult) await fansController.Get();

            //Assert
            result.StatusCode.Should().Be(200);
        }

        [Fact]
        public async Task Get_OnSuccess_InvokeService()
        {
            //Arrage
            var mockFanService = new Mock<IFanService>();

            mockFanService.Setup(service => service.GetAllFans())
                .ReturnsAsync(FansFixtures.GetFans());

            var fansController = new FansController(mockFanService.Object);

            //Act
            var result = (OkObjectResult) await fansController.Get();

            //Assert
            mockFanService.Verify(service => service.GetAllFans(), Times.Once); 

        }

        [Fact]
        public async Task Get_OnSuccess_ReturnListOfFans()
        {

            //Arrage
            var mockFanService = new Mock<IFanService>();

            mockFanService.Setup(service => service.GetAllFans())
                .ReturnsAsync(FansFixtures.GetFans());

            var fansController = new FansController(mockFanService.Object);

            //Act
            var result = (OkObjectResult)await fansController.Get();

            //Assert
            result.Should().BeOfType<OkObjectResult>();

            result.Value.Should().BeOfType<List<Fan>>();
        }

        [Fact]
        public async Task Get_OnNoFans_ReturnNotFound()
        {
            //Arrage
            var mockFanService = new Mock<IFanService>();

            mockFanService.Setup(service => service.GetAllFans())
                .ReturnsAsync(new List<Fan>());

            var fansController = new FansController(mockFanService.Object);

            //Act
            var result = (NotFoundResult)await fansController.Get();


            //Assert
            result.Should().BeOfType<NotFoundResult>();

        }
    }
}
