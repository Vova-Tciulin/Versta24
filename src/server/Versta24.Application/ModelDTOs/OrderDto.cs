namespace Versta24.Application.ModelDTOs;

public class OrderDto
{
    public Guid Id { get; set; }
    public string SenderCity { get; set; }
    public string SenderAddress { get; set; }
    public string RecipientCity { get; set; }
    public string RecipientAddress { get; set; }
    public decimal CargoWeight { get; set; }
    public DateTime DateReceived { get; set; }
}