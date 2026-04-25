
namespace JobOffer.Application.Services.Typies.Handlers
{
    public class DeleteTypeHandler : IRequestHandler<DeleteType, bool>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteTypeHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<bool> Handle(DeleteType request, CancellationToken cancellationToken)
        {

            var repo = _unitOfWork.GetReposoitory<Typess, int>();
            var type = await repo.GetByIdAsync(request.id, cancellationToken);

            if (type == null) return false;

            await repo.DeleteAsync(request.id);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return true;

        }
    }
}
