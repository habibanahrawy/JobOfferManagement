

namespace JobOffer.Application.Features.Categories.Handlers
{
    public class UpdateCategoryHandler : IRequestHandler<UpdateCategory, bool>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateCategoryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(UpdateCategory request, CancellationToken cancellationToken)
        {

            var repo = _unitOfWork.GetReposoitory<Category, int>();
            var category = await repo.GetByIdAsync(request.id);

            if(category == null) return false;

            category.Name = request.name;

            await repo.UpdateAsync(category);
            await _unitOfWork.SaveChangesAsync();

            return true;


        }
    }
}
