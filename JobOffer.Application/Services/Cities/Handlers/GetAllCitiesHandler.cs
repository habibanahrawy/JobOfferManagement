

namespace JobOffer.Application.Services.Cities.Handlers
{
    public class GetAllCitiesHandler : IRequestHandler<GetAllCities, IEnumerable<CityDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllCitiesHandler(IUnitOfWork unitOfWork , IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CityDTO>> Handle(GetAllCities request, CancellationToken cancellationToken)
        {

            var city = await _unitOfWork.GetReposoitory<City, int>().GetAllAsync(cancellationToken);

            return _mapper.Map<IEnumerable<CityDTO>>(city);


        }
    }
}
