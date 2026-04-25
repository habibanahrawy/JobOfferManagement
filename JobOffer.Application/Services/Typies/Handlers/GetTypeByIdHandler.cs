
namespace JobOffer.Application.Services.Typies.Handlers
{
    public class GetTypeByIdHandler : IRequestHandler<GetTypeById, TypeDTO?>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetTypeByIdHandler(IUnitOfWork unitOfWork , IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<TypeDTO?> Handle(GetTypeById request, CancellationToken cancellationToken)
        {

            var type = await _unitOfWork.GetReposoitory<Typess, int>().GetByIdAsync(request.id, cancellationToken);

            if (type == null) return null;

            return _mapper.Map<TypeDTO>(type);



        }
    }
}
