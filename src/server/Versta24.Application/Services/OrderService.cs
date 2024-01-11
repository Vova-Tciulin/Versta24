using AutoMapper;
using Versta24.Application.ModelDTOs;
using Versta24.Domain.Entities;
using Versta24.Infrastructure.Repositories;

namespace Versta24.Application.Services;

public class OrderService:IOrderService
{
    private readonly IOrderRepository _orderRepository;
    private readonly IMapper _map;

    public OrderService(IOrderRepository orderRepository, IMapper map)
    {
        _orderRepository = orderRepository;
        _map = map;
    }

    public async Task<OrderDto> GetOrderByIdAsync(Guid orderId)
    {
        var order = await _orderRepository.GetOrderByIdAsync(orderId);

        return _map.Map<OrderDto>(order);
    }

    public async Task<List<OrderDto>> GetOrdersAsync()
    {
        var orders = await _orderRepository.GetOrdersAsync();

        return _map.Map<List<OrderDto>>(orders);
    }

    public async Task CreateOrderAsync(CreateOrderDto model)
    {
        
        var order = _map.Map<Order>(model);
        order.Id = Guid.NewGuid();
        
        _orderRepository.AddOrder(order);
        await _orderRepository.SaveChangesAsync();
    }
}