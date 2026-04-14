

namespace JobOffer.Core.Entities
{
    public class User : IdentityUser
    {
        public string FullName { get; set; } = string.Empty;
        public string? CV { get; set; }


        #region Relations
        public Gender gender { get; set; }


        public int CityId { get; set; }
        public City city { get; set; } = null!;


        #endregion
    }
}
