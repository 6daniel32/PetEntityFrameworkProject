public abstract class Supportable {
    public Guid SupportableId { get; set; }

    // Navigation property to retrieve support centres
    public ICollection<SupportableSupportCentre> SupportableSupportCentres { get; set; } = new List<SupportableSupportCentre>();
    // We can do this after configuring the polymorphic many-to-many relationship
    public IEnumerable<SupportCentre> SupportCentres => SupportableSupportCentres.Select(
        supportableSupportCentre => supportableSupportCentre.SupportCentre
    );
}