using Odeon.Entities.Common;

namespace Odeon.Entities
{
    public class HotelRoom : BaseEntity
    {
        public decimal Price { get; set; }
        public int MaxAllotment { get; set; }
        public int SoldAllotment { get; set; }
        public Guid HotelId { get; set; }
        public Hotel Hotel { get; set; }
        public Guid RoomTypeId { get; set; }
        public RoomType RoomType { get; set; }
        public ICollection<Reservation> Reservations { get; set; }
    }
}
