
namespace JobOffer.Core
{
    public abstract class BaseEntity<TKey>
    {
        public TKey Id { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
        public string? CreatedBy { get; set; }
        public DateTime? EditedOn { get; set; }
        public string? EditedBy { get; set; } 
        public DateTime? DeletedOn { get; set; }
        public string? DeletedBy { get; set; } 
        public bool IsDeleted { get; set; } = false;
    }
}
