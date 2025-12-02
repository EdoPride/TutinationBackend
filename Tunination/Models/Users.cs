namespace Tutination;

public class Users
{
 public int UserID { get; set; }
    public string ?FullName { get; set; }
    public string ?Email { get; set; }
    public string ?PhoneNumber { get; set; }
    public string ?PasswordHash { get; set; }
    public string ?Role { get; set; }
    public DateTime ?DateRegistered { get; set; }

    // Navigation
    public List<Tickets> ?Tickets { get; set; }
    public List<EventBookings> ?EventBookings { get; set; }
    public List<Appointments> ?Appointments { get; set; }
    public List<Payments> ?Payments { get; set; }
}
