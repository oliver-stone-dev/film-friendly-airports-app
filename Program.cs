
using film_friendly_airports_app.Services;
using Microsoft.EntityFrameworkCore;

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
        builder.Services.AddSwaggerGen();

        //Add database context with default connection string
        builder.Services.AddDbContext<Database>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

        //Add services
        builder.Services.AddScoped<ISearchService, SearchService>();
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

        app.MapControllers();

        app.Run();
    }
}
