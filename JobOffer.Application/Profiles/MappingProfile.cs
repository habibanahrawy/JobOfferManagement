
namespace JobOffer.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Category , CategoryDTO>().ReverseMap();
            CreateMap<CreateCategory, Category>().ReverseMap();

            CreateMap<City , CityDTO>().ReverseMap();
            CreateMap<CreateCity , City>().ReverseMap();

            CreateMap<Country , CountryDTO>().ReverseMap();
            CreateMap<CreateCountry , Country>().ReverseMap();

            CreateMap<Typess , TypeDTO>().ReverseMap();
            CreateMap<CreateType , Type>().ReverseMap();
        }
    }
}
