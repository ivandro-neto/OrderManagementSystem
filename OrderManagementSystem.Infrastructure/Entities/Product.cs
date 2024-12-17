using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace OrderManagementSystem.Infrastructure.Entities;

public class Product
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();

    [Required]
    [NotNull]
    public string Name { get; set; } = string.Empty;

    [Required]
    [NotNull]
    public string Description { get; set; } = string.Empty;

    [Required]
    public double Price { get; set; }


}