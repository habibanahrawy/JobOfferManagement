

namespace JobOffer.Core.Entities
{
    public class JobApplicated : BaseEntity<int>
    {

        public int JobOfferId { get; set; }
        public JobOffered jobOffered { get; set; } = null!;


        public string UserId { get; set; }
        public User user { get; set; } = null!;


        public Status status { get; set; }

    }
}
