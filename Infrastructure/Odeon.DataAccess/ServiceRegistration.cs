using Microsoft.Extensions.DependencyInjection;
using Odeon.DataAccess.Contexts;
using Odeon.Application.Repositories;
using Odeon.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Odeon.DataAccess
{
    public static class ServiceRegistration
    {
        public static void AddDataAccessServices(this IServiceCollection services)
        {
            services.AddDbContext<OdeonDbContext>(options => options.UseSqlServer(Configuration.ConnectionString, b => b.MigrationsAssembly("Odeon.DataAccess")));

            services.AddScoped<IHotelReadRepository, HotelReadRepository>();
            services.AddScoped<IHotelWriteRepository, HotelWriteRepository>();
            services.AddScoped<IHotelRoomReadRepository, HotelRoomReadRepository>();
            services.AddScoped<IHotelRoomWriteRepository, HotelRoomWriteRepository>();
            services.AddScoped<IReservationReadRepository, ReservationReadRepository>();
            services.AddScoped<IReservationWriteRepository, ReservationWriteRepository>();
            services.AddScoped<IRoomTypeReadRepository, RoomTypeReadRepository>();
            services.AddScoped<IRoomTypeWriteRepository, RoomTypeWriteRepository>();
        }
    }
}
