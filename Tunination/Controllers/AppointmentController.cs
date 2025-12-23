using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Org.BouncyCastle.Crypto.Paddings;
using Tunination;
using Tunitation;

namespace Tunination.Controllers;
[ApiController]
[Route("api/[controller]")]

public class AppointmentController : ControllerBase
{
   private readonly ITutination tdb;
     private readonly EmailService _emailService;
    public AppointmentController(ITutination tutination, EmailService emailService)
    {
        tdb = tutination;
        _emailService = emailService;
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
    { var appointment = await tdb.GetAppointmentByIdAsync(id);
    if (appointment == null)
        return NotFound(new { message = "Appointment not found", success = false });

    appointment.Status = "Accepted";
    // 🔥 SEND EMAIL AFTER ACCEPTANCE
var user = await tdb.GetByIdAsync(appointment.UserID);

// 1️⃣ Get correct payment link based on Service Type
string paymentLink = "";

if (appointment.ServiceType == "Music Studio")
{
    paymentLink = await tdb.GetStudioPaymentLinkAsync(1); 
}
else if (appointment.ServiceType == "Podcast")
{
    paymentLink = await tdb.GetPodcastPaymentLinkAsync(1);
}

// 2️⃣ Prepare payment instruction message 
string paymentMessage = $@"
<br><br>
Please make your payment using the link below:<br>
<b><a href='{paymentLink}'>{paymentLink}</a></b>
<br><br>
Your booking will be confirmed once payment is received.
";

// 3️⃣ Send email
await _emailService.SendEmailAsync(
    user?.Email,
    "Your Appointment Has Been Accepted",
    $@"
Hello {user?.FullName},<br/><br/>

Your appointment for <b>{appointment.ServiceType}</b><br/>
on <b>{appointment.AppointmentDate:dddd, MMM dd}</b><br/>
at <b>{appointment.StartTime}</b> has been <b>ACCEPTED</b>.<br/><br/>

{paymentMessage}

Thank you for choosing our service!<br/>
"
);
//update appointment status
    var success = await tdb.UpdateAppointmentAsync(appointment);

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

    // 🔥 SEND EMAIL AFTER REJECTION
    var user = await tdb.GetByIdAsync(appointment.UserID);
    await _emailService.SendEmailAsync(
        user?.Email,
        "Your Appointment Has Been Rejected",
        $@"
            Hello {user?.FullName},<br/><br/>
            We regret to inform you that your appointment for 
            <b>{appointment.ServiceType}</b><br/>
            on <b>{appointment.AppointmentDate:dddd, MMM dd}</b> 
            at <b>{appointment.StartTime}</b><br/>
            has been <b>REJECTED</b>.<br/><br/>

            If you believe this is an error or would like to reschedule, 
            please contact us.<br/><br/>

            Thank you for choosing our service!
        "
    );
    //update appointment status
    var rejected = await tdb.UpdateAppointmentAsync(appointment);

    return Ok(new { message = "Appointment rejected successfully", success = true });
}



[HttpGet("Appointment-Table")]
public async Task<IActionResult> GetAppointmentTable ()
{
   var Appointments = await  tdb.GetAllAppointmentsAsync();
   if (Appointments == null)
   {
       return Ok(new List<Appointments>());
   }

   var FrontAppointment = Appointments.Select(a => new Appointments
   {
       AppointmentDate = a.AppointmentDate,
       UserID = a.UserID,
       ServiceType = a.ServiceType,
       AppointmentID = a.AppointmentID,
       StartTime = a.StartTime,
       EndTime = a.EndTime,
       Status = a.Status,
       Notes = a.Notes

   });

   return Ok(FrontAppointment);
}



    }
    
