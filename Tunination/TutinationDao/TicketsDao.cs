namespace Tutination;

public class TicketsDao
{
 public int TicketID { get; set; }
    public int EventID { get; set; }
    public int UserID { get; set; }
    public string ?QRCode { get; set; }
    public DateTime PurchaseDate { get; set; }
    public string ?TicketType { get; set; }
    public decimal ?PricePaid { get; set; }

    // Navigation
    public Events ?Event { get; set; }
    public Users ?User { get; set; }
}
