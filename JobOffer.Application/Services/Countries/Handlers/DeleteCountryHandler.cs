
namespace JobOffer.Application.Servicess.Countries.Handlers
{
    public class DeleteCountryHandler : IRequestHandler<DeleteCountry, bool>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteCountryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(DeleteCountry request, CancellationToken cancellationToken)
        {
            var repo = _unitOfWork.GetReposoitory<Country, int>();

            var country = await repo.GetByIdAsync(request.id, cancellationToken);

            if(country == null) return false;

            await repo.DeleteAsync(request.id);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return true;


        }
    }
}
