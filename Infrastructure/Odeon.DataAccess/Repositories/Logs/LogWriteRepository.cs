using Odeon.Application.Repositories;
using Odeon.DataAccess.Contexts;
using Odeon.Entities;

namespace Odeon.DataAccess.Repositories
{
    public class LogWriteRepository : WriteRepository<Log>, ILogWriteRepository
    {
        public LogWriteRepository(OdeonDbContext context) : base(context) { }
    }
}
