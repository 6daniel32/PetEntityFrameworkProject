using System.ComponentModel.DataAnnotations;

public class Test {
    public Guid TestId { get; set; }
    [MaxLength(50)]
    public string Title { get; set; }
    // ManyToMany relationship with the Trainee model. EF Core knows
    // that this is a ManyToMany relationship because the Trainee model
    // also declares that is related with many tests with:
    // "public ICollection<Test> Tests { get; } = new List<Test>();"
    // This is enough for EF Core to know that a pivot table needs to be
    // created to store the relationship between the two models.
    public ICollection<Trainee> Trainees { get; } = new List<Trainee>();

    public Test(string title) {
        Title = title;
    }
}