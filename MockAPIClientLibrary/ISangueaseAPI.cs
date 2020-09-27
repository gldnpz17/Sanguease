using MockAPIClientLibrary.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MockAPIClientLibrary
{
    public interface ISangueaseAPI
    {
        Task AddBDEvent(BDEvent model);
        Task DeleteBDEvent(int id);
        Task<BDEvent> GetBDEventByIdAsync(int id);
        Task<List<BDEvent>> GetBDEventsAsync();
        Task<string> GetLocationByCoordinatesAsync(decimal latitude, decimal longitude);
        Task UpdateBDEvent(int id, BDEvent model);
    }
}