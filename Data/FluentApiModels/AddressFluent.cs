public class AddressFluent {
    public int AddressId { get; set; }
    public string Street { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string Country { get; set; }
    public Guid CompanyId { get; set; }
    public CompanyFluent Company { get; set; } = null!;

    public AddressFluent(
        string street,
        string city,
        string state,
        string country
    ) {
        Street = street;
        City = city;
        State = state;
        Country = country;
    }
}