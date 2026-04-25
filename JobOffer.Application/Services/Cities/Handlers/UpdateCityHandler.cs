

namespace JobOffer.Application.Services.Cities.Handlers
{
    public class UpdateCityHandler : IRequestHandler<UpdateCity, bool>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateCityHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(UpdateCity request, CancellationToken cancellationToken)
        {
            var repo = _unitOfWork.GetReposoitory<City, int>();
            var city = await repo.GetByIdAsync(request.id , cancellationToken);

            if(city == null) return false;

            city.Name = request.name;
            city.CountryId = request.CountryId;

            await repo.UpdateAsync(city);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return true;

            
        }
    }
}
