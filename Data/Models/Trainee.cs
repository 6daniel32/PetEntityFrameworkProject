using System.ComponentModel.DataAnnotations;

public class Trainee {
    public Guid TraineeId { get; set; }
    [MaxLength(50)]
    public string Name { get; set; }
    // This model is the child of a OneToMany relationship with the
    // Company model. The relationship indicates that the foreign 
    // key can't be null. Forcing trainees to belong to a company.
    // This property that references the parent model of the relationship 
    // is known as a "reference navigation" property.
    public Company Company { get; set; } = null!;
    // Navigation properties for the ManyToMany relationships with
    // Tests and Courses.
    public ICollection<Test> Tests { get; } = new List<Test>();
    public ICollection<Course> Courses { get; } = new List<Course>();
    
    public Trainee(string name) {
        Name = name;
    }
}