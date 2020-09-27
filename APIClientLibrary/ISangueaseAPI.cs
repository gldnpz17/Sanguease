using APIClientLibrary.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace APIClientLibrary
{
    public interface ISangueaseAPI
    {
        Task AddBDEventAsync(BDEvent model);
        Task DeleteBDEventAsync(int id);
        Task<BDEvent> GetBDEventByIdAsync(int id);
        Task<List<BDEvent>> GetBDEventsAsync();
        Task<string> GetLocationByCoordinatesAsync(decimal latitude, decimal longitude);
        Task UpdateBDEventAsync(int id, BDEvent model);
    }
}