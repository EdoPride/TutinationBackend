using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Tunination;

namespace Tunination.Controllers;
[ApiController]
[Route("api/[controller]")]

public class EventsController : ControllerBase
{
   private readonly ITutination tdb;

    public EventsController(ITutination tutination)
    {
        tdb = tutination;
    }

[HttpPost("add")]
public async Task<IActionResult> AddEvents([FromForm] EventsDao model)
{
    if (model == null)
        return BadRequest("Invalid payload");

    if (model.Image != null)
    {
        using var ms = new MemoryStream();
        await model.Image.CopyToAsync(ms);
        model.ImageBytes = ms.ToArray();

        // Save imageBytes to DB, OR save file to folder here
    }

     model.StartDate = model.StartDate?.ToUniversalTime();
     model.EndDate = model.EndDate?.ToUniversalTime();
     model.RemainingCapacity = model.Capacity;
    await tdb.AddEventAsync(model);
    return Ok(new { message = "Event added successfully", eventId = model.EventID });
}

//get all events
[HttpGet("All-Events")]
public async Task<IActionResult> GetAllEvents()
{
    var events = await tdb.GetAllEventsAsync();
    return Ok(events);
}

    [HttpPost("Delete-Event/{id}")]
    public async Task<IActionResult> DeleteEvent(int id)
    {
        var success = await tdb.DeleteEventAsync(id);
        if (!success)
            return NotFound(new { message = "Event not found or could not be deleted", success = false });

        return Ok(new { message = "Event deleted successfully", success = true });
    }

/*

[HttpPost("login")]
public async Task<IActionResult> Login([FromBody] LoginModel model)
{
   

    [HttpPost("logout")]
    public async Task<IActionResult> Logout()
    {
       
    }
*/
    }
    
