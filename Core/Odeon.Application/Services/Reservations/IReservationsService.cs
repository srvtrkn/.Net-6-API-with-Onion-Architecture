
using Odeon.Application.ViewModels.Reservations;
using Odeon.Application.ViewModels.Responses;

namespace Odeon.Application.Services.Reservations
{
    public interface IReservationsService
    {
        Task<Response<string>> CreateReservation(CreateReservationRequest req);
        Task<Response<string>> CancelReservation(string resevationId);
    }
}
