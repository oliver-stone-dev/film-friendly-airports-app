using Microsoft.EntityFrameworkCore;
using film_friendly_airports_app.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace film_friendly_airports_app;

public class AppDbContext : IdentityDbContext<Account>
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    public DbSet<Airport> Airports { get; set; }
    public DbSet<Terminal> Terminals { get; set; }
    public DbSet<Review> Reviews { get; set; }
    public DbSet<Report> Reports { get; set; }
    public DbSet<ReportType> ReportTypes { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        //builder.HasDefaultSchema("Identity");
    }
}
