public class SupportableSupportCentre
{
    public Guid SupportableId { get; set; }
    public Supportable Supportable { get; set; } = null!;

    public Guid SupportCentreId { get; set; }
    public SupportCentre SupportCentre { get; set; } = null!;
}