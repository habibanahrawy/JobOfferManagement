
namespace JobOffer.Application.Services.Cities.Handlers
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
            var city = await repo.GetByIdAsync(request.id, cancellationToken);

            if (city == null) return false;

            await repo.DeleteAsync(request.id);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return true;


        }
    }
}
