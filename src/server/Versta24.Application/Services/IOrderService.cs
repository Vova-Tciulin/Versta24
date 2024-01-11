using Versta24.Application.ModelDTOs;

namespace Versta24.Application.Services;

public interface IOrderService
{
    Task<OrderDto> GetOrderByIdAsync(Guid orderId);
    Task<List<OrderDto>> GetOrdersAsync();
    Task CreateOrderAsync(CreateOrderDto model);
    
}