using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Tunination;

namespace Tunination.Controllers;
[ApiController]
[Route("api/[controller]")]

public class AuthController : ControllerBase
{
   private readonly ITutination tdb;

    public AuthController(ITutination tutination)
    {
        tdb = tutination;
    }

[HttpPost("register")]
public async Task<IActionResult> Register([FromBody] UsersDao model)
{
    if (model == null)
        return BadRequest("Invalid payload");

    // Basic validation
    if (string.IsNullOrEmpty(model.Email) || string.IsNullOrEmpty(model.PasswordHash))
        return BadRequest("Email and password are required.");
//check if email exists
    var existingUser =  await tdb.GetByEmailAsync(model.Email);
    if (existingUser != null)
        return Conflict("Email is already in use.");    

    model.DateRegistered = DateTime.UtcNow;
    model.Role = "User";  // Force user role
   model.PasswordHash = BCrypt.Net.BCrypt.HashPassword(model.PasswordHash);
    await tdb.AddAsync(model);

    return Ok(new {
        message = "Registration successful",
        userId = model.UserID
        //addd an email to congrats the use
    });
}


    [HttpPost("verify")]
    public async Task<IActionResult> Verify()
    {
        return Ok();
    }
[HttpPost("login")]
public async Task<IActionResult> Login([FromBody] LoginModel model)
{
    if (string.IsNullOrEmpty(model.Email) || string.IsNullOrEmpty(model.Password))
        return BadRequest("Email and password are required.");
    bool success = false;
    var user = await tdb.GetByEmailAsync(model.Email);
    if (user == null)
        return NotFound(new { message = "User not found", success });

    if (!BCrypt.Net.BCrypt.Verify(model.Password, user.PasswordHash))
        return Unauthorized(new { message = "Invalid password", success });

    success = true;
    return Ok(new { message = "Login successful", userId = user.UserID, userName = user.FullName ,role = user.Role , success = true });
}

    [HttpPost("logout")]
    public async Task<IActionResult> Logout()
    {
        return Ok();
    }

    }
    
