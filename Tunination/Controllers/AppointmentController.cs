using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Tunination;

namespace Tunination.Controllers;
[ApiController]
[Route("api/[controller]")]

public class AppointmentController : ControllerBase
{
   private readonly ITutination tdb;

    public AppointmentController(ITutination tutination)
    {
        tdb = tutination;
    }

[HttpPost("Book-Appointment")]
public async Task<IActionResult> AddAppointment([FromForm] AppointmentsDao model)
{
    if (model == null)
        return BadRequest("Invalid payload");

     model.AppointmentDate = model.AppointmentDate.ToUniversalTime();
     model.Status="Pending";
    await tdb.AddAppointmentAsync(model);
    return Ok(new { message = "Appointment booked successfully", appointmentId = model.AppointmentID });
}

//get all appointments
[HttpGet("All-Appointments")]
public async Task<IActionResult> GetAllAppointments()
{
    var appointments = await tdb.GetAllAppointmentsAsync();
    return Ok(appointments);
}

    [HttpPost("Delete-Appointment/{id}")]
    public async Task<IActionResult> DeleteAppointment(int id)
    {
        var success = await tdb.DeleteAppointmentAsync(id);
        if (!success)
            return NotFound(new { message = "Appointment not found or could not be deleted", success = false });

        return Ok(new { message = "Appointment deleted successfully", success = true });
    }


//accept and reject appointment endpoints can be added here
[HttpPost("Accept-Appointment/{id}")]
public async Task<IActionResult> AcceptAppointment(int id)
    {
        var appointment = await tdb.GetAppointmentByIdAsync(id);
        if (appointment == null)
            return NotFound(new { message = "Appointment not found", success = false });

        appointment.Status = "Accepted";
        var success = await tdb.UpdateAppointmentAsync(appointment);
        if (!success)
            return StatusCode(500, new { message = "Could not update appointment status", success = false });

        return Ok(new { message = "Appointment accepted successfully", success = true });
    }
[HttpPost("Reject-Appointment/{id}")]
public async Task<IActionResult> RejectAppointment(int id)
    {
        var appointment = await tdb.GetAppointmentByIdAsync(id);
        if (appointment == null)
            return NotFound(new { message = "Appointment not found", success = false });

        appointment.Status = "Rejected";
        var success = await tdb.UpdateAppointmentAsync(appointment);
        if (!success)
            return StatusCode(500, new { message = "Could not update appointment status", success = false });

        return Ok(new { message = "Appointment rejected successfully", success = true });
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
    
