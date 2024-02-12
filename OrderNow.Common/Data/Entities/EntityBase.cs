namespace OrderNow.Common.Data.Entities
{
    public class EntityBase
    {
        public DateTime Created { get; set; }

        public DateTime? Deleted { get; set; } = null;

        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        public DateTime LastModified { get; set; } = DateTime.UtcNow;
    }
}