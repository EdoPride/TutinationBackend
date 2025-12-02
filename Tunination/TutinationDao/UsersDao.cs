namespace Tunination;

public class UsersDao
{
    public int UserID { get; set; }
    public string ?FullName { get; set; }
    public string ?Email { get; set; }
    public string ?PhoneNumber { get; set; }
    public string ?PasswordHash { get; set; }
    public string ?Role { get; set; }
    public DateTime ?DateRegistered { get; set; }

    // Navigation
    public List<TicketsDao> ?Tickets { get; set; }
    public List<EventBookingsDao> ?EventBookings { get; set; }
    public List<AppointmentsDao> ?Appointments { get; set; }
    public List<PaymentsDao> ?Payments { get; set; }

}
