
namespace JobOffer.Application.Features.Cities.Handlers
{
    public class GetCityByIdHandler : IRequestHandler<GetCityById, CityDTO?>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetCityByIdHandler(IUnitOfWork unitOfWork , IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<CityDTO?> Handle(GetCityById request, CancellationToken cancellationToken)
        {
            var city = await _unitOfWork.GetReposoitory<City, int>().GetByIdAsync(request.id);

            if(city == null) return null;

            return _mapper.Map<CityDTO>(city);
        
        }

    }
}
