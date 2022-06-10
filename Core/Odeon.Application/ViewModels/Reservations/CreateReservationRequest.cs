namespace Odeon.Application.ViewModels.Reservations
{
    public class CreateReservationRequest
    {
        public string HotelId { get; set; }
        public string RoomTypeId { get; set; }
        public int RequestedRoomCount { get; set; }
        public DateTime BookingDateStart { get; set; }
        public DateTime BookingDateEnd { get; set; }
    }
}
