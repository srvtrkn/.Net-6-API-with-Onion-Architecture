using Microsoft.Extensions.DependencyInjection;
using Odeon.Application.Services.Logs;
using Odeon.Application.Services.Reservations;
using Odeon.Application.Services.Room;

namespace Odeon.Application
{
    public static class ServiceRegistration
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IRoomService, RoomService>();
            services.AddScoped<IReservationsService, ReservationsService>();
            services.AddScoped<ILogService, LogService>();
        }
    }
}
