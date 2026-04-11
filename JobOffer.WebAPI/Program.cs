using JobOffer.Application.Contracts;
using JobOffer.Application.Features.Categories.Handlers;
using JobOffer.Application.Profiles;
using JobOffer.Core.Contracts;
using JobOffer.Core.Entities;
using JobOffer.Infrastructure.DbContexts;
using JobOffer.Infrastructure.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MediatR;
using JobOffer.Application.Features.Typies.Handlers;


public partial class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
        builder.Services.AddOpenApi();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddDbContext<AppDbContext>(options =>
        {
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));

        });

        builder.Services.AddIdentity<User, IdentityRole>()
               .AddEntityFrameworkStores<AppDbContext>();

        builder.Services.AddAutoMapper(X => X.LicenseKey = "", typeof(MappingProfile).Assembly);
        builder.Services.AddScoped<IUnitOfWork , UnitOfWork>();
        builder.Services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssembly(typeof(GetAllCategoriesHandler).Assembly);
        });
        builder.Services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssembly(typeof(GetAllTypiesHandler).Assembly);
        });

        var app = builder.Build();

       

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.MapOpenApi();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/openapi/v1.json", "JobOfferManagement API");
            });
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}