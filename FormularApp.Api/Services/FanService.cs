using FormularApp.Api.Models;
using FormularApp.Api.Services.Interfaces;

namespace FormularApp.Api.Services
{
    public class FanService : IFanService
    {
        private readonly HttpClient _httpClient;
        public FanService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Fan>> GetAllFans()
        {
            throw new NotImplementedException();
        }
    }
}
