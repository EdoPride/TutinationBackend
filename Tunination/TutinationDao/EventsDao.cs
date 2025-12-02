namespace Tutination;

public class EventsDao
{
  public int EventID { get; set; }
    public string ?Title { get; set; }
    public string ?Description { get; set; }
    public string ?Location { get; set; }
    public DateTime ?StartDate { get; set; }
    public DateTime ?EndDate { get; set; }
    public decimal ?Price { get; set; }
    public int ?Capacity { get; set; }
    public int ?RemainingCapacity { get; set; }

    // Navigation
    public List<TicketsDao> ?Tickets { get; set; }
    public List<EventBookingsDao> ?EventBookings { get; set; }
}
