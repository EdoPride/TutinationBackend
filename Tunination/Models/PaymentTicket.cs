namespace Tunination;

public class PaymentTicket
{
  public int PaymentID { get; set; }
    public int TicketID { get; set; }

    // Navigation
    public Payments ?Payment { get; set; }
    public Tickets ?Ticket { get; set; }
}
