using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Tutination.Models;

namespace Tutination.Controllers;

public class TicketController : Controller
{
   private readonly ITutination tdb;

    public TicketController(ITutination tutination)
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
