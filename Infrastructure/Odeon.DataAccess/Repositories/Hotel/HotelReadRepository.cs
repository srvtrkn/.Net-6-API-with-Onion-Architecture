using Odeon.Application.Repositories;
using Odeon.DataAccess.Contexts;
using Odeon.Entities;
using Odeon.Persistence.Repositories;

namespace Odeon.DataAccess.Repositories
{
    public class HotelReadRepository : ReadRepository<Hotel>, IHotelReadRepository
    {
        public HotelReadRepository(OdeonDbContext context) : base(context) { }
    }
}
