using Odeon.Application.Repositories;
using Odeon.DataAccess.Contexts;
using Odeon.Entities;

namespace Odeon.DataAccess.Repositories
{
    public class ReservationWriteRepository : WriteRepository<Reservation>, IReservationWriteRepository
    {
        public ReservationWriteRepository(OdeonDbContext context) : base(context) { }
    }
}
