using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace OrderManagementSystem.Infrastructure.Entities;

public class Order
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();

    [Required]
    [ForeignKey("ClientId")]
    public Guid ClientId { get; set; } 
    
    [Required]
    [ForeignKey("ProductId")]
    public Guid ProductId { get; set; }

    public string Status { get; set; } = "Pendente";

}