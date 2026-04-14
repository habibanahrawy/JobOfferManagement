

namespace JobOffer.Application.Features.Typies.Handlers
{
    public class CreateTypeHandler : IRequestHandler<CreateType, TypeDTO>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateTypeHandler(IUnitOfWork unitOfWork , IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<TypeDTO> Handle(CreateType request, CancellationToken cancellationToken)
        {

            var type = new Types
            {
                Name = request.name
            };

            await _unitOfWork.GetReposoitory<Types , int>().CreateAsync(type);
            await _unitOfWork.SaveChangesAsync();
            return _mapper.Map<TypeDTO>(type);

        }
    }
}
