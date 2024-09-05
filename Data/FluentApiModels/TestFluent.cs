public class TestFluent {
    public Guid TestId { get; set; }
    public string Title { get; set; }
    public ICollection<TraineeFluent> Trainees { get; } = new List<TraineeFluent>();

    public TestFluent(string title) {
        Title = title;
    }
}