
namespace JobOffer.Application.Services.Categories.Handlers
{
    public class GetAllCategoriesHandler : IRequestHandler<GetAllCategories, IEnumerable<CategoryDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllCategoriesHandler(IUnitOfWork unitOfWork , IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CategoryDTO>> Handle(GetAllCategories request, CancellationToken cancellationToken)
        {
            var categories =await _unitOfWork.GetReposoitory<Category , int>().GetAllAsync(cancellationToken);
            return _mapper.Map<IEnumerable<CategoryDTO>>(categories);


        }
    }

}
