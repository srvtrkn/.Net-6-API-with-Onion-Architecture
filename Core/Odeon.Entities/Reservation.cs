using Odeon.Entities.Common;

namespace Odeon.Entities
{
    public class Reservation : BaseEntity
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int RoomCount { get; set; }
        public Guid HotelRoomId { get; set; }
        public HotelRoom HotelRoom { get; set; }
    }
}
