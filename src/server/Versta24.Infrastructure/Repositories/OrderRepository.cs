using Microsoft.EntityFrameworkCore;
using Versta24.Domain.Entities;
using Versta24.Domain.Exceptions;
using Versta24.Infrastructure.Data;

namespace Versta24.Infrastructure.Repositories;

public class OrderRepository(VerstaDbContext db) : IOrderRepository
{
    public async Task<List<Order>> GetOrdersAsync()
    {
        return await db.Orders.ToListAsync();
    }

    public async Task<Order> GetOrderByIdAsync(Guid orderId)
    {
        var order = await db.Orders.FirstOrDefaultAsync(u => u.Id == orderId);

        if (order==null)
        {
            throw new NotFoundException($"order with id: {orderId} not found!");
        }

        return order;
    }

    public void AddOrder(Order order)
    {
        db.Orders.Add(order);
    }

    public async Task SaveChangesAsync()
    {
        await db.SaveChangesAsync();
    }
}