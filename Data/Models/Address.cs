using System.ComponentModel.DataAnnotations;

public class Address {
    // For EF Core to consider the column as the primary key of the
    // model, you need to name it as "Id" or "{ModelName}Id".
    // EF Core also supports integer id's as primary keys.
    public int AddressId { get; set; }
    [MaxLength(50)]
    public string Street { get; set; }
    [MaxLength(50)]
    public string City { get; set; }
    [MaxLength(50)]
    public string State { get; set; }
    [MaxLength(50)]
    public string Country { get; set; }
    // This model participates in a OneToOne relationship with the Company, 
    // which is optional for the Company model. This property that references
    // the parent company model.
    // Because on OneToOne relationships, the foreign key
    // could be placed in any of the two models, we need to
    // declare it explicitly in one of the models (the dependent one, 
    // when the relationship is optional for one of the models and 
    // mandatory for the other model, like in this case, where it's 
    // mandatory for the Address model, or any of them, when the relationship
    // is mandatory for both models or optional for both).
    public Guid CompanyId { get; set; }
    public Company Company { get; set; } = null!;

    public Address(
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