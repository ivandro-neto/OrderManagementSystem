using System.ComponentModel.DataAnnotations;

namespace OrderManagementSystem.Infrastructure.Entities;

public class Client
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();

    [Required]
    [StringLength(50)]
    public string Name { get; set; } = string.Empty;
    [Required]
    [StringLength(100)]
    public string Address { get; set; } = string.Empty;
}