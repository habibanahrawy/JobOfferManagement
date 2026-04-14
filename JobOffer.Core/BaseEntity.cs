

namespace JobOffer.Core
{
    public abstract class BaseEntity<TKey>
    {
        public TKey Id { get; set; }
    }
}
