using Odeon.Entities.Common;

namespace Odeon.Entities
{
    public class RoomType : BaseEntity
    {
        public string RoomTypeName { get; set; }
        public ICollection<HotelRoom> HotelRooms { get; set; }
    }
}
