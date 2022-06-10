namespace Odeon.Entities.Common
{
    public class BaseEntity
    {
        public Guid Id { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public Guid? LogicalDeleteKey { get; set; }
    }
}
