using Microsoft.EntityFrameworkCore;
using Odeon.Entities.Common;

namespace Odeon.Application.Repositories
{
    public interface IRepository<T> where T : BaseEntity
    {
        DbSet<T> Table { get; }
    }
}
