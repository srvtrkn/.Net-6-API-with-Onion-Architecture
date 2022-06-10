using Odeon.Application.Repositories;
using Odeon.DataAccess.Contexts;
using Odeon.Entities;
using Odeon.Persistence.Repositories;

namespace Odeon.DataAccess.Repositories
{
    public class RoomTypeReadRepository : ReadRepository<RoomType>, IRoomTypeReadRepository
    {
        public RoomTypeReadRepository(OdeonDbContext context) : base(context) { }
    }
}
