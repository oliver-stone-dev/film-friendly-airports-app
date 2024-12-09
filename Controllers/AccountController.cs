using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using film_friendly_airports_app.Models;
using film_friendly_airports_app.DataTransferObjects;
using Microsoft.AspNetCore.Authorization;

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

    [HttpGet, Route("/account/exists")]
    public async Task<ActionResult<bool>> Exists([FromQuery] string email)
    {
        return Ok(await _userManager.FindByEmailAsync(email) != null);
    }

    [Authorize]
    [HttpGet]
    public async Task<ActionResult<AccountDTO>> GetAccount()
    {
        var userAccount = await _userManager.GetUserAsync(User);

        if (userAccount == null)
        {
            return NotFound();
        }

        var dto = userAccount.ToAccountDTO();

        return Ok(dto);
    }
}
