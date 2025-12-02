namespace Tunination;

public class MyServices
{
 public int ServiceID { get; set; }
    public string ?ServiceName { get; set; }
    public string ?Description { get; set; }
    public decimal ?Price { get; set; }
    public int ?DurationMinutes { get; set; }

    // Navigation
    public List<Appointments> ? Appointments { get; set; }
}

