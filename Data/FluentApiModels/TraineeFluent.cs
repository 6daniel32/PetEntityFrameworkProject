public class TraineeFluent {
    public Guid TraineeId { get; set; }
    public string Name { get; set; }
    public CompanyFluent Company { get; set; } = null!;
    // Fluent API version of the model doesn't rely on conventions
    // and demands the foreign key to be explicitly defined
    public Guid CompanyId { get; set; }
    public ICollection<TestFluent> Tests { get; } = new List<TestFluent>();
    
    public TraineeFluent(string name) {
        Name = name;
    }
}