using Microsoft.AspNetCore.Mvc;
using Odeon.Application.Services.Room;
using Odeon.Application.ViewModels.Room;

namespace Odeon.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private readonly IRoomService roomService;
        public RoomController(IRoomService roomService)
        {
            this.roomService = roomService;
        }
        [HttpGet]
        public async Task<IActionResult> GetCheapestRoomPrices()
        {
            var result = await roomService.GetCheapestRoomPrices();
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> AdvancedRoomSearch(RoomSearchRequest req)
        {
            var result = await roomService.AdvancedRoomSearch(req);
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> RoomAvailabilityCheck(RoomAvailabilityCheckRequest req)
        {
            var result = await roomService.RoomAvailabilityCheck(req);
            return Ok(result);
        }
    }
}
