namespace Tutination;

public class AppointmentsDao
{
     public int AppointmentID { get; set; }
    public int UserID { get; set; }
    public int ServiceID { get; set; }
    public DateTime AppointmentDate { get; set; }
    public TimeSpan StartTime { get; set; }
    public TimeSpan EndTime { get; set; }
    public string ?Status { get; set; }
    public string ?Notes { get; set; }

    // Navigation
    public Users ?User { get; set; }
    public Services ?Service { get; set; }

}
