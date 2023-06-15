using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class Employee
{
    [Key]
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    public int CompanyId { get; set; }
    public virtual Company Company { get; set; }
}