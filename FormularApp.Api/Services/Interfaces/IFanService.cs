using FormularApp.Api.Models;

namespace FormularApp.Api.Services.Interfaces
{
    public interface IFanService
    {
        Task<List<Fan>?> GetAllFans();
    }
}
