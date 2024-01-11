namespace Versta24.Api.Models;

public class OrderVm
{
    public Guid Id { get; set; }
    public string SenderCity { get; set; }
    public string SenderAddress { get; set; }
    public string RecipientCity { get; set; }
    public string RecipientAddress { get; set; }
    public decimal CargoWeight { get; set; }
    public DateTime DateReceived { get; set; }
}