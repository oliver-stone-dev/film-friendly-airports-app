using Microsoft.EntityFrameworkCore;
using film_friendly_airports_app.Models;

namespace film_friendly_airports_app;

public class Database : DbContext
{
    public Database(DbContextOptions<Database> options) : base(options) { }

    public DbSet<Airport> Airports { get; set; }
    public DbSet<Terminal> Terminals { get; set; }
    public DbSet<Review> Reviews { get; set; }
 }
