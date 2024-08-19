using System.ComponentModel.DataAnnotations;

public class Test {
    public Guid TestId { get; set; }
    [MaxLength(50)]
    public string Title { get; set; }
    public ICollection<Trainee> Trainees { get; } = new List<Trainee>();

    public Test(string title) {
        Title = title;
    }
}