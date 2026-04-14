

namespace JobOffer.Application.Features.Cities.Handlers
{
    public class DeleteCityHandler : IRequestHandler<DeleteCity, bool>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteCityHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(DeleteCity request, CancellationToken cancellationToken)
        {

            var repo = _unitOfWork.GetReposoitory<City, int>();
            var city = await repo.GetByIdAsync(request.id);

            if (city == null) return false;

            await repo.DeleteAsync(request.id);
            await _unitOfWork.SaveChangesAsync();
            return true;


        }
    }
}
