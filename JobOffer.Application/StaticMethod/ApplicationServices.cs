
using JobOffer.Application.Profiles;
using Microsoft.Extensions.DependencyInjection;

namespace JobOffer.Application.StaticMethod
{
    public static class ApplicationServices
    {

        public static IServiceCollection AddApplicationServices(this IServiceCollection Services )
        {
            Services.AddAutoMapper(X => X.LicenseKey = "", typeof(MappingProfile).Assembly);

            Services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(typeof(ApplicationServices).Assembly);
            });

            return Services;

        }

    }
}
