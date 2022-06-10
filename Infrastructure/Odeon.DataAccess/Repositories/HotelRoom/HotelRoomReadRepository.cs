using Microsoft.EntityFrameworkCore;
using Odeon.Application.Repositories;
using Odeon.DataAccess.Contexts;
using Odeon.Entities;
using Odeon.Persistence.Repositories;

namespace Odeon.DataAccess.Repositories
{
    public class HotelRoomReadRepository : ReadRepository<HotelRoom>, IHotelRoomReadRepository
    {
        public HotelRoomReadRepository(OdeonDbContext context) : base(context) { }
        public IQueryable<HotelRoom> GetCheapestRoom() =>
            Table.FromSqlRaw(@"SELECT hr.*     
                                FROM HotelRooms hr INNER JOIN
                                (
                                    SELECT HotelId, MIN(Price) price
                                    FROM HotelRooms h
                                    where h.LogicalDeleteKey is null
	                                GROUP BY h.HotelId		
                                ) CheapestRooms ON hr.Price = CheapestRooms.price and hr.HotelId=CheapestRooms.HotelId");

    }
}
