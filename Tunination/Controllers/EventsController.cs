using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Tunination;
using Tunitation;

namespace Tunination.Controllers;
[ApiController]
[Route("api/[controller]")]

public class EventsController : ControllerBase
{
   private readonly ITutination tdb;
     private readonly EmailService _emailService;

    public EventsController(ITutination tutination, EmailService emailService)
    {
        tdb = tutination;
        _emailService = emailService;
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

    [HttpDelete("delete/{id}")]
    public async Task<IActionResult> DeleteEvent(int id)
    {
        var success = await tdb.DeleteEventAsync(id);
        if (!success)
            return NotFound(new { message = "Event not found or could not be deleted", success = false });

        return Ok(new { message = "Event deleted successfully", success = true });
    }
[HttpPost("purchase")]
[Consumes("multipart/form-data")]
public async Task<IActionResult> PurchaseTicket(
    [FromForm] PaymentTicketDao dto,
    [FromForm] IFormFile receipt
)
{
    if (dto == null)
        return BadRequest("Invalid payment data");

    if (receipt == null)
        return BadRequest("Receipt is required");

    using var ms = new MemoryStream();
    await receipt.CopyToAsync(ms);
    var receiptBytes = ms.ToArray();

    await _emailService.SendEmailAsynctoAdmin(
        recipientEmail: "admin@example.com",
        subject: "New Ticket Purchase Receipt",
        body: "A new ticket payment proof was uploaded.",
        attachment: receiptBytes
    );
dto.PaymentStatus = "Pending";
dto.PaymentDate = DateTime.UtcNow;
//currency euro
dto.Currency = "EUR";

    await tdb.AddPaymentReferenceAsync(dto);

    return Ok(new { message = "Pending payment created" });
}
//get all payment 
[HttpGet("payments-Tickets")]
public async Task<IActionResult> GetAllPaymentsTickets()
{
    var payments = await tdb.GetAllPaymentByReferenceAsync();
    return Ok(payments);
}

        //accept confirm payment
                [HttpPut("payments-tickets/status")]
public async Task<IActionResult> UpdatePaymentStatus(
    [FromForm] int PaymentID,
    [FromForm] string status,
    [FromForm] int userId
)
{
    var success = await tdb.UpdatePaymentReferenceAsync(PaymentID, status);

    if (!success)
        return NotFound("Ticket not found");

    return Ok(new { message = "Payment status updated", userId });
}
//send the ticket email of ticket to  user after payment
[HttpPost("send-ticket-email/{userId}")]
public async Task<IActionResult> SendTicketEmail(
    int userId,
    [FromForm] IFormFile ticket
)
{
    if (ticket == null || ticket.Length == 0)
        return BadRequest("Ticket file is required");

    var user = await tdb.GetByIdAsync(userId);
    if (user == null)
        return NotFound("User not found");

    // Save file temporarily or convert to attachment
    using var stream = new MemoryStream();
    await ticket.CopyToAsync(stream);
    stream.Position = 0;
 /*   await _emailService.SendEmailAsynctoUser(
        user.Email,
        "Your Event Ticket",
        "Thank you for your payment. Your ticket is attached.",
        stream,
        ticket.FileName
    );*/

    return Ok(new { message = "Ticket email sent successfully" });
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
  
