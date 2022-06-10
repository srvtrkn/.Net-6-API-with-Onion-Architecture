using Odeon.Application.Repositories;
using Odeon.DataAccess.Contexts;
using Odeon.Entities;

namespace Odeon.DataAccess.Repositories
{
    public class HotelRoomWriteRepository : WriteRepository<HotelRoom>, IHotelRoomWriteRepository
    {
        public HotelRoomWriteRepository(OdeonDbContext context) : base(context) { }
    }
}
