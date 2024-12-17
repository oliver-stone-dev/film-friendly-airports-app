using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using film_friendly_airports_app.Models;
using film_friendly_airports_app.DataTransferObjects;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace film_friendly_airports_app.Controllers;

[Route("/account")]
[ApiController]
public class AccountController : ControllerBase
{
    private readonly UserManager<Account> _userManager;
    private readonly SignInManager<Account> _signinManager;
    private readonly IConfiguration _configuration;

    public AccountController (UserManager<Account> userManager, SignInManager<Account> signinManager, IConfiguration configuration)
    {
        _userManager = userManager;
        _signinManager = signinManager;
        _configuration = configuration;
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

    [HttpPost, Route("/account/displayname")]
    public async Task<ActionResult> SetDisplayName(AccountRegisterDTO accountRegister)
    {
        if (string.IsNullOrEmpty(accountRegister.DisplayName))
        {
            return BadRequest();
        }

        var user = await _userManager.FindByEmailAsync(accountRegister.Email!);

        if (user == null)
        {
            return NotFound();
        }

        if (await _userManager.CheckPasswordAsync(user, accountRegister.Password!) == false)
        {
            return Unauthorized();
        }

        user.DisplayName = accountRegister.DisplayName;

        var result = await _userManager.UpdateAsync(user);

        if (result.Succeeded)
        {
            return Ok();
        }
        else
        {
            return BadRequest(result.Errors);
        }
    }
}
