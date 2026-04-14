

namespace JobOffer.Application.Features.Typies.Handlers
{
    public class UpdateTypeHandler : IRequestHandler<UpdateType, bool>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateTypeHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(UpdateType request, CancellationToken cancellationToken)
        {

            var repo = _unitOfWork.GetReposoitory<Types, int>();
            var type = await repo.GetByIdAsync(request.id);

            if (type == null) return false;

            type.Name = request.name;

            await repo.UpdateAsync(type);
            await _unitOfWork.SaveChangesAsync();
            return true;

        }
    }
}
