
namespace JobOffer.Application.Features.Countries.Handlers
{
    public class UpdateCountryHandler : IRequestHandler<UpdateCountry, bool>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateCountryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(UpdateCountry request, CancellationToken cancellationToken)
        {

            var repo = _unitOfWork.GetReposoitory<Country, int>();
            var country = await repo.GetByIdAsync(request.id);

            if (country == null) return false;

            country.Name = request.name;

            await repo.UpdateAsync(country);
            await _unitOfWork.SaveChangesAsync();

            return true;



        }
    }
}
