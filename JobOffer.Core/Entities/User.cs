
namespace JobOffer.Core.Entities
{
    public class User : IdentityUser
    {
        public string FullName { get; set; } = null!;
        public string? CVFile { get; set; } 
        public string? RefreshToken { get; set; }
        public DateTime? ExpiredTimeToken { get; set; }

        #region Relations

        public Gender Gender { get; set; }


        public int CityId { get; set; }
        public City city { get; set; } = null!;


        #endregion

    }
}
