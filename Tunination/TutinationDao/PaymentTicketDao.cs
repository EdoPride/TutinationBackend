namespace Tunination;

public class PaymentTicketLinkDao
{
 public int PaymentID { get; set; }
    public int AppointmentID { get; set; }

    // Navigation
    public Payments ?Payment { get; set; }
    public Tickets ?Ticket { get; set; }
}
