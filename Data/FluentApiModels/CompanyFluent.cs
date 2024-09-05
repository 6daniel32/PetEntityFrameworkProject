public class CompanyFluent {
    public Guid CompanyId { get; set; }
    public string Name { get; set; }
    public ICollection<TraineeFluent> Trainees { get; } = new List<TraineeFluent>();    
    public AddressFluent? Address { get; set; }

    public CompanyFluent(string name) {
        Name = name;
    }
}