
using film_friendly_airports_app.Models;
using film_friendly_airports_app.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;

namespace film_friendly_airports_app;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen(options => {

            options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
            {
                In = ParameterLocation.Header,
                Name = "Authorization",
                Type = SecuritySchemeType.ApiKey
            });

            options.OperationFilter<SecurityRequirementsOperationFilter>();
        });

        if (builder.Environment.IsDevelopment())
        {
            builder.Services.AddCors(options =>
            {
                options.AddDefaultPolicy(policy =>
                {
                    //pass origin into new uri and check if localhost
                    policy.SetIsOriginAllowed(origin => new Uri(origin).Host == "localhost");
                });
            });
        }

        //Add identity core
        builder.Services.AddAuthorization();
        builder.Services.AddIdentityApiEndpoints<Account>()
            .AddEntityFrameworkStores<AppDbContext>();

        //Add database context with default connection string
        builder.Services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

        //Add services
        builder.Services.AddScoped<IReviewService, ReviewService>();
        builder.Services.AddScoped<IAirportService, AirportService>();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.UseCors();

        app.MapControllers();

        app.MapIdentityApi<Account>();

        app.Run();
    }
}
