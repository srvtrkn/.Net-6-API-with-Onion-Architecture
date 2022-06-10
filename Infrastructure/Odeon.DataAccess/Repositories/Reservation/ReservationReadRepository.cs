using Odeon.Application.Repositories;
using Odeon.DataAccess.Contexts;
using Odeon.Entities;
using Odeon.Persistence.Repositories;

namespace Odeon.DataAccess.Repositories
{
    public class ReservationReadRepository : ReadRepository<Reservation>, IReservationReadRepository
    {
        public ReservationReadRepository(OdeonDbContext context) : base(context) { }
    }
}
