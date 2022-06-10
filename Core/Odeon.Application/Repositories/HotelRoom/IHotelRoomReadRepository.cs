using Odeon.Entities;

namespace Odeon.Application.Repositories
{
    public interface IHotelRoomReadRepository : IReadRepository<HotelRoom>
    {
        IQueryable<HotelRoom> GetCheapestRoom();
    }
}
