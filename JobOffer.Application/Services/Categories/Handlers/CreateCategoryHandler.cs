
namespace JobOffer.Application.Services.Categories.Handlers
{
    public class CreateCategoryHandler : BaseCreateHandler<CreateCategory, Category, CategoryDTO>
    {
        public CreateCategoryHandler(IUnitOfWork unitOfWork, IMapper mapper)
            : base(unitOfWork, mapper)
        {
        }
    }
}
