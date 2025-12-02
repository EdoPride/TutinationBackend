using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Tunination;

namespace Tunination.Controllers;

public class AuthController : Controller
{
   private readonly ITutination tdb;

    public AuthController(ITutination tutination)
    {
        tdb = tutination;
    }

    public async Task<IActionResult> Register()
    {
        return View();
    }
   public async Task<IActionResult> Verify()
    {
        return View();
    }
    public async Task<IActionResult> Login()
    {
        return View();
    }


    public async Task<IActionResult> Logout()
    {
        return View();
    }


}
