namespace Tunination;

public class PaymentLinksDao
{
    public int Id { get; set; }
    public string? PodcastPaymentLink { get; set; }
    public string? StudioPaymentLink { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}
