using Odeon.Application.Repositories;
using Odeon.DataAccess.Contexts;
using Odeon.Entities;

namespace Odeon.DataAccess.Repositories
{
    public class RoomTypeWriteRepository : WriteRepository<RoomType>, IRoomTypeWriteRepository
    {
        public RoomTypeWriteRepository(OdeonDbContext context) : base(context) { }
    }
}
