using System.ComponentModel.DataAnnotations;

public class SupportCentre {
    public Guid SupportCentreId { get; set; }
    [MaxLength(50)]
    public string Title { get; set; }
    [MaxLength(50)]
    public string Language { get; set; }
    [MaxLength(50)]
    public string Workload { get; set; }
    // This is a way to configure a ManyToMany Polymorphic 
    // relationship. We need to use a Join Entity to handle
    // the many-to-many relationship between inheritors of "Supportable"
    // and "SupportCentre". Used as a navigation property to the join entity.
    public ICollection<SupportableSupportCentre> SupportableSupportCentres { get; } = new List<SupportableSupportCentre>();

    // We can do this after configuring the polymorphic many-to-many relationship
    public IEnumerable<Test?> Tests => SupportableSupportCentres
        .Where(supportableSupportCentre => supportableSupportCentre.Supportable is Test)
        .Select(supportableSupportCentre => supportableSupportCentre.Supportable as Test);
    // We can do this after configuring the polymorphic many-to-many relationship
    public IEnumerable<Course?> Courses => SupportableSupportCentres
        .Where(supportableSupportCentre => supportableSupportCentre.Supportable is Course)
        .Select(supportableSupportCentre => supportableSupportCentre.Supportable as Course);

    public SupportCentre(
        string title,
        string language,
        string workload    
    ) {
        Title = title;
        Language = language;
        Workload = workload;
    }
}