namespace Tutination;

public class EventBookings
{
 public int BookingID { get; set; }
    public int EventID { get; set; }
    public int UserID { get; set; }
    public DateTime BookedDate { get; set; }
    public string ?Status { get; set; }

    // Navigation
    public Events ?Event { get; set; }
    public Users ?User { get; set; }
}
