
namespace JobOffer.Application.DTOs
{
    public class ResetPassDTO
    {
        public string Email { get; set; }
        public string Token { get; set; }
        public string NewPassWord { get; set; }
        public string ConfirmPassword { get; set; }


    }
}
