using FluentAssertions;
using FormularApp.Api.Configuration;
using FormularApp.Api.Models;
using FormularApp.Api.Services;
using FormularApp.UnitTests.Fixtures;
using FormularApp.UnitTests.Helpers;
using Microsoft.Extensions.Options;
using Moq;
using Moq.Protected;

namespace FormularApp.UnitTests.Systems.Services
{
    public class TestFanService
    {
        [Fact]
        public async Task GetAllFans_OnInvoke_HttpGet()
        {
            //Arrange
            var Url = "https://ultrapay.co.za/api/v1/fans";
            var response = FansFixtures.GetFans();
            var mockHandler = MockHttpHandler<Fan>.SetupGetRequest(response);
            var httpClient = new HttpClient(mockHandler.Object);

            var config = Options.Create(new ApiServiceConfig()
            {
                Url = Url
            });

            var fanService = new FanService(httpClient, config);

            //Act
            await fanService.GetAllFans();

            //Assert
            mockHandler.Protected().Verify("SendAsync", Times.Once(), ItExpr.Is<HttpRequestMessage>(r => 
                r.Method == HttpMethod.Get && r.RequestUri.ToString() == Url), ItExpr.IsAny<CancellationToken>());
        }

        [Fact]
        public async Task GetAllFans_OnInvoke_ListOfFans()
        {
            //Arrange
            var Url = "https://ultrapay.co.za/api/v1/fans";
            var response = FansFixtures.GetFans();
            var mockHandler = MockHttpHandler<Fan>.SetupGetRequest(response);
            var httpClient = new HttpClient(mockHandler.Object);

            var config = Options.Create(new ApiServiceConfig()
            {
                Url = Url
            });

            var fanService = new FanService(httpClient, config);

            //Act
            var result = await fanService.GetAllFans();

            //Assert
            result.Should().BeOfType<List<Fan>>();
        }
        [Fact]
        public async Task GetAllFans_OnInvoke_ReturnEmptyList()
        {
            //Arrange
            var Url = "https://ultrapay.co.za/api/v1/fans";
            var mockHandler = MockHttpHandler<Fan>.SetupReturnNotFound();
            var httpClient = new HttpClient(mockHandler.Object);

            var config = Options.Create(new ApiServiceConfig()
            {
                Url = Url
            });

            var fanService = new FanService(httpClient, config);

            //Act
            var result = await fanService.GetAllFans();

            //Assert
            result.Count.Should().Be(0);
        }
    }
}
