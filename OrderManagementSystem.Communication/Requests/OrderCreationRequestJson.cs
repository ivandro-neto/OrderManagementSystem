using OrderManagementSystem.Infrastructure.Entities;
using System.ComponentModel.DataAnnotations;

namespace OrderManagementSystem.Communication.Requests;

public class OrderCreationRequestJson
{
    [Required]
    public Guid ClientId { get; set; }
    [Required]
    public Guid productId { get; set; }

    [Required]
    public string Status { get; set; } = "Pendente";
}