

namespace JobOffer.Application.Features.Cities.Handlers
{
    public class CreateCityHandler : IRequestHandler<CreateCity, CityDTO>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateCityHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<CityDTO> Handle(CreateCity request, CancellationToken cancellationToken)
        {

            var city = new City()
            {
                Name = request.name,
                CountryId = request.CountryId

            };

            await _unitOfWork.GetReposoitory<City, int>().CreateAsync(city);

            await _unitOfWork.SaveChangesAsync();
            return _mapper.Map<CityDTO>(city);


        }
    }
}
