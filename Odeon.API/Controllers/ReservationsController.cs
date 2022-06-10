using Microsoft.AspNetCore.Mvc;
using Odeon.Application.Services.Reservations;
using Odeon.Application.ViewModels.Reservations;

namespace Odeon.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ReservationsController : ControllerBase
    {
        private readonly IReservationsService reservationsService;
        public ReservationsController(IReservationsService reservationsService)
        {
            this.reservationsService = reservationsService;
        }
        [HttpPost]
        public async Task<IActionResult> CreateReservation(CreateReservationRequest req)
        {
            var result = await reservationsService.CreateReservation(req);
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> CancelReservation(string reservationId)
        {
            var result = await reservationsService.CancelReservation(reservationId);
            return Ok(result);
        }
    }
}
