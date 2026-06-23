using System.ComponentModel.DataAnnotations; // Required

namespace MySqlEf.Api.Models;

public class Person
{
    public int Id { get; set; }

    [Required]
    [MaxLength(100)]
    public required string Name { get; set; }

    [Required]
    public int Age { get; set; }

}