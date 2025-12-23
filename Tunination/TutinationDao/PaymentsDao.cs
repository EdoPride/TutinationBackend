namespace Tunination;

public class PaymentsDao
{
   
     public int PaymentID { get; set; }
    public int UserID { get; set; }
    public int EventID { get; set; }

    public decimal Amount { get; set; }
    public string ?Currency { get; set; }
    public DateTime ?PaymentDate { get; set; }
    public string ?PaymentStatus { get; set; }

}
