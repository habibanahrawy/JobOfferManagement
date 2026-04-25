
namespace JobOffer.Application.DTOs
{
    public class RegisterDTO
    {
        public string FullName { get; set; } = null!;
        public string UserName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public int CityId { get; set; }
        public int Gender { get; set; } 
        public IFormFile CV { get; set; } 

    }
}
