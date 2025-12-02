namespace Tutination;

public class Payments
{
   public int PaymentID { get; set; }
    public int UserID { get; set; }
    public decimal Amount { get; set; }
    public string ?Currency { get; set; }
    public string ?PaymentMethod { get; set; }
    public DateTime ?PaymentDate { get; set; }
    public string ?PaymentStatus { get; set; }
    public string ?ReferenceID { get; set; }

    // Navigation
    public Users ?User { get; set; }
}
