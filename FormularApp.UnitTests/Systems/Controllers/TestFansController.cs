using FluentAssertions;
using FormularApp.Api.Controllers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormularApp.UnitTests.Systems.Controllers
{
    public class TestFansController
    {
        [Fact]
        public async Task Get_OnSuccess_ReturnsStatausCode200()
        {
            //Arrage
            var fansController = new FansController();

            //Act
            var result = (OkObjectResult) await fansController.Get();

            //Assert
            result.StatusCode.Should().Be(200);
        }
    }
}
