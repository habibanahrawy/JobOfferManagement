namespace JobOffer.Application.DTOs
{
    public class AuthDTO
    {
        public string Token { get; set; }
        public string RefreshToken { get; set; }
        public DateTime ExpiredTime { get; set; }
    }
}
