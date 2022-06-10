using Microsoft.EntityFrameworkCore;
using Odeon.Entities;
using Odeon.Entities.Common;

namespace Odeon.DataAccess.Contexts
{
    public class OdeonDbContext : DbContext
    {
        public OdeonDbContext(DbContextOptions options) : base(options) { }
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<HotelRoom> HotelRooms { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<RoomType> RoomTypes { get; set; }
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var datas = ChangeTracker
                 .Entries<BaseEntity>();

            foreach (var data in datas)
            {
                _ = data.State switch
                {
                    EntityState.Added => data.Entity.CreatedDate = DateTime.Now,
                    EntityState.Modified => data.Entity.UpdatedDate = DateTime.Now,
                    _ => DateTime.Now
                };
            }
            return await base.SaveChangesAsync(cancellationToken);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<HotelRoom>().HasOne(p => p.Hotel).WithMany(p => p.HotelRooms).HasForeignKey(p => p.HotelId);
            modelBuilder.Entity<HotelRoom>().HasOne(p => p.RoomType).WithMany(p => p.HotelRooms).HasForeignKey(p => p.RoomTypeId);

            modelBuilder.Entity<Reservation>().HasOne(p => p.HotelRoom).WithMany(p => p.Reservations).HasForeignKey(p => p.HotelRoomId);
        }
    }
}
