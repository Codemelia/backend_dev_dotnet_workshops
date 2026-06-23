using System.ComponentModel.DataAnnotations; // Required

namespace MySqlEf.Api.DTO;

// Instead of taking whole model, only use subset of attributes
public class PersonRead
{

    public int Id { get; set; }

    [Required]
    [MaxLength(100)]
    public required string Name { get; set; }

    [Required]
    public int Age { get; set; }

}