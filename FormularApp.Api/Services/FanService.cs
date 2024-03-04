using FormularApp.Api.Configuration;
using FormularApp.Api.Models;
using FormularApp.Api.Services.Interfaces;
using Microsoft.Extensions.Options;
using System.Net;

namespace FormularApp.Api.Services
{
    public class FanService : IFanService
    {
        private readonly HttpClient _httpClient;
        private readonly ApiServiceConfig _config;
        public FanService(HttpClient httpClient, IOptions<ApiServiceConfig> config)
        {
            _httpClient = httpClient;
            _config = config.Value;
        }

        public async Task<List<Fan>?> GetAllFans()
        {
            var response = await _httpClient.GetAsync(_config.Url);

            switch (response.StatusCode)
            {
                case HttpStatusCode.NotFound:
                    return new List<Fan>();
                case HttpStatusCode.Unauthorized:
                    return null;
                default:
                    return await response.Content.ReadFromJsonAsync<List<Fan>>();
            }
        }
    }
}
