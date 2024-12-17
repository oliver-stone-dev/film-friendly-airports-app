using Microsoft.AspNetCore.Identity;

namespace film_friendly_airports_app.Models;

public class Account : IdentityUser
{
    public string? DisplayName { get; set; }
    public ICollection<Report> Reports { get; } = new List<Report>();
    public ICollection<Review> Reviews { get; } = new List<Review>();
}
