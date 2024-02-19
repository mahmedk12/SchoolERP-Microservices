namespace Staff.Domain.Common
{
    public abstract class EntityBase
    {
        public DateTime CreatedDate { get; set; }
        public DateTime? LastModifiedDate { get; set; }
    }
}
