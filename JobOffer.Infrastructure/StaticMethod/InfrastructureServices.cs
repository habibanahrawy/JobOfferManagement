
using JobOffer.Infrastructure.DataSeed;
using JobOffer.Infrastructure.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;


namespace JobOffer.Infrastructure.StaticMethod
{
    public static class InfrastructureServices
    {

        public static IServiceCollection AddInfrastructureServices(this IServiceCollection Services, IConfiguration configuration)
        {
            Services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));

            });


            Services.AddIdentity<User, IdentityRole>()
                    .AddEntityFrameworkStores<AppDbContext>();


            Services.AddScoped<IUnitOfWork, UnitOfWork>();

            Services.AddScoped<IAttachmentService, AttachmentService>();

            Services.AddScoped<ITokenService, TokenService>();

            Services.AddScoped<RoleSeed>();

            Services.AddHttpContextAccessor();

            Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

            }).AddJwtBearer(options =>
            {
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = configuration["JWTOptions:Issuer"],
                    ValidAudience = configuration["JWTOptions:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWTOptions:SecretKey"]!))
                };
            });

            

            return Services;
        }

        
        public static async Task Initializer(this IServiceProvider serviceProvider)
        {

            using var scope = serviceProvider.CreateScope();
            var dbcontext = scope.ServiceProvider.GetRequiredService<AppDbContext>();

            await dbcontext.Database.MigrateAsync();

            await scope.ServiceProvider.GetRequiredService<RoleSeed>().Seeding();
        }

    }
}
