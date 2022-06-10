using Odeon.Application.ViewModels.Responses;
using Odeon.Application.ViewModels.Room;

namespace Odeon.Application.Services.Room
{
    public interface IRoomService
    {
        Task<ResponseList<CheapestRoom>> GetCheapestRoomPrices();
        Task<ResponseList<CheapestRoom>> AdvancedRoomSearch(RoomSearchRequest req);
        Task<Response<bool>> RoomAvailabilityCheck(RoomAvailabilityCheckRequest req);
    }
}
