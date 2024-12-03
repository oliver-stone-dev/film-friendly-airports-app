using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using film_friendly_airports_app.Models;

namespace film_friendly_airports_app.Controllers;

[Route("/account")]
[ApiController]
public class AccountController : ControllerBase
{
    private readonly UserManager<Account> _userManager;

    public AccountController (UserManager<Account> userManager)
    {
        _userManager = userManager;
    }

    [HttpGet]
    public async Task<ActionResult<bool>> GetEmailExists([FromQuery] string email)
    {
        return Ok(await _userManager.FindByEmailAsync(email) != null);
    }
}
