using JobOffer.Application.StaticMethod;
using JobOffer.Infrastructure.StaticMethod;

public partial class Program
{
    private static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);



        builder.Services
               .AddOpenApi()
               .AddEndpointsApiExplorer()
               .AddApplicationServices()
               .AddInfrastructureServices(builder.Configuration)
               .AddControllers();


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

        app.UseAuthentication();
        app.UseAuthorization();

        app.MapControllers();

        await app.Services.Initializer();

        await app.RunAsync();
    }
}