

namespace JobOffer.Application.Features.Countries.Handlers
{
    public class CreateCountryHandler : IRequestHandler<CreateCountry, CountryDTO>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateCountryHandler(IUnitOfWork unitOfWork , IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<CountryDTO> Handle(CreateCountry request, CancellationToken cancellationToken)
        {

            var country = new Country()
            {
                Name = request.name
            };


            await _unitOfWork.GetReposoitory<Country, int>().CreateAsync(country);
            await _unitOfWork.SaveChangesAsync();
            return _mapper.Map<CountryDTO>(country);


        }
    }
}
