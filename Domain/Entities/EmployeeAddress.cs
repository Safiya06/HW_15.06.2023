using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class EmployeeAddress
{
    public string Address { get; set; }
    [Key]
    public int EmployeeId { get; set; }
    public virtual Employee Employee { get; set; }
}