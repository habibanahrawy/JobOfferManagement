
using JobOffer.Core.Enums;

namespace JobOffer.Application.DTOs
{
    public class EmployeeDTO
    {
        public string FullName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string CompanyName { get; set; } 
        public int CityId { get; set; }
        public Gender Gender { get; set; }
    }
}
