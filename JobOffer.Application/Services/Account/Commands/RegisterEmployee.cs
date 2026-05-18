
namespace JobOffer.Application.Services.Account.Commands
{
    public record RegisterEmployee(EmployeeDTO employeeDTO) : IRequest<bool>;
}
