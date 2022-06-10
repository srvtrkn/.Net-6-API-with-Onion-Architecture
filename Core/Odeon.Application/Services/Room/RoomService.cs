using Odeon.Application.Repositories;
using Odeon.Application.ViewModels.Responses;
using Odeon.Application.ViewModels.Room;

namespace Odeon.Application.Services.Room
{
    public class RoomService : IRoomService
    {
        private readonly IHotelRoomReadRepository hotelRoomReadRepository;
        public RoomService(IHotelRoomReadRepository hotelRoomReadRepository)
        {
            this.hotelRoomReadRepository = hotelRoomReadRepository;
        }
        public async Task<ResponseList<CheapestRoom>> GetCheapestRoomPrices()
        {
            var result = hotelRoomReadRepository.GetCheapestRoom().Select(h => new CheapestRoom
            {
                HotelId = h.Hotel.Id.ToString(),
                HotelName = h.Hotel.HotelName,
                RoomTypeId = h.RoomType.Id.ToString(),
                RoomTypeName = h.RoomType.RoomTypeName,
                Price = h.Price
            }).OrderBy(h => h.Price).ThenBy(h => h.HotelName).ToList();
            return new ResponseList<CheapestRoom> { Success = true, DataList = result };
        }
        public async Task<ResponseList<CheapestRoom>> AdvancedRoomSearch(RoomSearchRequest req)
        {
            if (req.RoomTypeIds.Count > 0)
            {
                var result = hotelRoomReadRepository.GetWhere(h => !h.LogicalDeleteKey.HasValue && (req.HotelIds.Contains(h.HotelId.ToString()) || req.RoomTypeIds.Contains(h.RoomTypeId.ToString())), false)
                    .Select(h => new CheapestRoom
                    {
                        HotelId = h.Hotel.Id.ToString(),
                        HotelName = h.Hotel.HotelName,
                        RoomTypeId = h.RoomType.Id.ToString(),
                        RoomTypeName = h.RoomType.RoomTypeName,
                        Price = h.Price
                    }).OrderBy(h => h.Price).ThenBy(h => h.HotelName).ToList();
                return new ResponseList<CheapestRoom> { Success = true, DataList = result };
            }
            else return new ResponseList<CheapestRoom> { Success = false, Message = "Oda tipi bilgisi göndermeniz gerekmektedir" };
        }
        public async Task<Response<bool>> RoomAvailabilityCheck(RoomAvailabilityCheckRequest req)
        {
            var hRoom = await hotelRoomReadRepository.GetSingleAsync(h => !h.LogicalDeleteKey.HasValue && req.HotelIds.Contains(h.Hotel.Id.ToString()) && req.RoomTypeIds.Contains(h.RoomType.Id.ToString()), false);
            bool isEmptyRoom = hRoom != null && (hRoom.MaxAllotment - hRoom.SoldAllotment) >= req.RequestedRoomCount;
            return new Response<bool>
            {
                Success = isEmptyRoom,
                Message = isEmptyRoom ? "Rezervasyona uygun oda bulunmaktadır" : "Rezervasyona uygun oda bulunmamaktadır",
                Data = isEmptyRoom
            };
        }
    }
}
