using Odeon.Entities.Common;

namespace Odeon.Entities
{
    public class Hotel : BaseEntity
    {
        public string HotelName { get; set; }
        public virtual ICollection<HotelRoom> HotelRooms { get; set; }
    }
}
