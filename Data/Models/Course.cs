using System.ComponentModel.DataAnnotations;

public class Course : Supportable {
    [MaxLength(50)]
    public string Title { get; set; }
    public ICollection<Trainee> Trainees { get; } = new List<Trainee>();

    public Course(string title) {
        Title = title;
    }
}