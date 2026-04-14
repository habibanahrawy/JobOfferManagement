

namespace JobOffer.Core.Entities
{
    public class JobOffered : BaseEntity<int>
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Salary { get; set; }
        public DateTime ExpirationDate { get; set; }



        #region Relations

        public int TypeId { get; set; }
        public Types type { get; set; } = null!;


        public int CategoryId { get; set; }
        public Category category { get; set; } = null!;


        public ICollection<JobApplicated> Applicateds { get; set; } = new List<JobApplicated>();

        #endregion
    }
}
