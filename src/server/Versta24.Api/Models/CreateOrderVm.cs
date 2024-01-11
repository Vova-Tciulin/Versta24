using System.ComponentModel.DataAnnotations;

namespace Versta24.Api.Models;

public class CreateOrderVm
{
    [Required(ErrorMessage = "The SenderCity field is required.")]
    public string SenderCity { get; set; }

    [Required(ErrorMessage = "The SenderAddress field is required.")]
    public string SenderAddress { get; set; }

    [Required(ErrorMessage = "The RecipientCity field is required.")]
    public string RecipientCity { get; set; }

    [Required(ErrorMessage = "The RecipientAddress field is required.")]
    public string RecipientAddress { get; set; }

    [Required(ErrorMessage = "The CargoWeight field is required.")]
    public decimal CargoWeight { get; set; }

    [Required(ErrorMessage = "The DateReceived field is required.")]
    public DateTime DateReceived { get; set; }
}