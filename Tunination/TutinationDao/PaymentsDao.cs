namespace Tunination;

public class PaymentsDao
{
     public int PaymentID { get; set; }
    public int AppointmentID { get; set; }

    // Navigation
    public Payments ?Payment { get; set; }
    public Appointments ?Appointment { get; set; }

}
