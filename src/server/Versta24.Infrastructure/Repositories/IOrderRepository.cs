using Versta24.Domain.Entities;

namespace Versta24.Infrastructure.Repositories;

public interface IOrderRepository
{
    Task<List<Order>> GetOrdersAsync();
    Task<Order> GetOrderByIdAsync(Guid orderId);
    void AddOrder(Order order);
    Task SaveChangesAsync();
}