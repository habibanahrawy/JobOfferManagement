

namespace JobOffer.Core.Entities
{
    public class User : IdentityUser
    {
        public string FullName { get; set; } = null!;
        public string CVFile { get; set; } = null!;



        #region Relations

        public Gender Gender { get; set; }


        public int CityId { get; set; }
        public City city { get; set; } = null!;


        #endregion

    }
}
