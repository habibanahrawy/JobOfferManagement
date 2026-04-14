

namespace JobOffer.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Category , CategoryDTO>().ReverseMap();
            CreateMap<Types , TypeDTO>().ReverseMap();
            CreateMap<City , CityDTO>().ReverseMap();
            CreateMap<Country , CountryDTO>().ReverseMap();
        }
    }
}
