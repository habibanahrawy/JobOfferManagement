

namespace JobOffer.Core.Lookups
{
    public class City : BaseEntity<int>
    {
        public string Name { get; set; } = string.Empty;


        public int CountryId { get; set; }
        public Country country { get; set; } = null!;
    }
}
