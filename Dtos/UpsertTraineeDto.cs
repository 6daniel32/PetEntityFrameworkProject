using System.ComponentModel.DataAnnotations;

public readonly record struct UpsertEmployeeDto
{
    [Required]
    [MaxLength(50)]
    public string Name { get; init; }
    [Required]
    public Guid CompanyId { get; init; }

    public UpsertEmployeeDto(string name, Guid companyId)
    {
        Name = name;
        CompanyId = companyId;
    }
}