using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Tunination;

namespace Tunination.Controllers;
[ApiController]
[Route("api/[controller]")]

public class PaymentLinkController : ControllerBase
{
   private readonly ITutination tdb;

    public PaymentLinkController(ITutination tutination)
    {
        tdb = tutination;
    }

[HttpPost("Add-PaymentLink")]
public async Task<IActionResult> AddPaymentLink([FromForm] PaymentLinksDao model)
{
    if (model == null)
        return BadRequest("Invalid payload");

     model.CreatedAt = DateTime.UtcNow;
    return Ok(new { message = "Payment Link added successfully" });
}
//update payment links for podcast

[HttpPut("Update-PodcastPaymentLink/{id}")]
public async Task<IActionResult> UpdatePodcastPaymentLink(int id, [FromForm] string PodcastPaymentLink)
{
    if (string.IsNullOrEmpty(PodcastPaymentLink))
        return BadRequest("Invalid payload");

    var result = await tdb.UpdatePodcastPaymentLinkAsync(id, PodcastPaymentLink);
    if (!result)
        return NotFound("Payment link not found");

    return Ok(new { message = "Payment Link updated successfully" });
}
//update payment links for studio
[HttpPut("Update-StudioPaymentLink/{id}")]
public async Task<IActionResult> UpdateStudioPaymentLink(int id, [FromForm] string StudioPaymentLink)
{
    if (string.IsNullOrEmpty(StudioPaymentLink))
        return BadRequest("Invalid payload");

    var result = await tdb.UpdateStudioPaymentLinkAsync(id, StudioPaymentLink);
    if (!result)
        return NotFound("Payment link not found");

    return Ok(new { message = "Payment Link updated successfully" });
}
//get payment links
[HttpGet("Get-Podcast-Payment-Links/{id}")]
public async Task<IActionResult> GetPodcastPaymentLinks(int id)
{
    var result = await tdb.GetPodcastPaymentLinkAsync(id);
    if (result == null)
        return NotFound("Payment link not found");

    return Ok(result);
}
[HttpGet("Get-Studio-Payment-Links/{id}")]
public async Task<IActionResult> GetStudioPaymentLinks(int id)  
{
    var result = await tdb.GetStudioPaymentLinkAsync(id);
    if (result == null)
        return NotFound("Payment link not found");

    return Ok(result);      
}
//delete payment links
[HttpDelete("Delete-Podcast-Payment-Link/{id}")]
public async Task<IActionResult> DeletePodcastPaymentLink(int id)
{
    var result = await tdb.DeletePodcastPaymentLinkAsync(id);
    if (!result)
        return NotFound("Payment link not found");

    return Ok(new { message = "Payment Link deleted successfully" });
}

[HttpDelete("Delete-Studio-Payment-Link/{id}")]
public async Task<IActionResult> DeleteStudioPaymentLink(int id)
{
    var result = await tdb.DeleteStudioPaymentLinkAsync(id);
    if (!result)
        return NotFound("Payment link not found");

    return Ok(new { message = "Payment Link deleted successfully" });
}
//getall payment links
[HttpGet("Get-All-Payment-Links")]
public async Task<IActionResult> GetAllPaymentLinks()
{
    var result = await tdb.GetAllPaymentLinksAsync();
    if (result == null || !result.Any())
        return NotFound("No payment links found");

    return Ok(result);  
}
}
