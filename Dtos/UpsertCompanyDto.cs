using System.ComponentModel.DataAnnotations;

public readonly record struct UpsertCompanyDto
{
    [Required]
    [MaxLength(50)]
    public string Name { get; init; }

    public UpsertCompanyDto(string name)
    {
        Name = name;
    }
}