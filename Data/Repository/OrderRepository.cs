using Microsoft.EntityFrameworkCore;
using Models;

namespace Data.Repository;

public class OrderRepository : IOrderRepository
{
    private readonly CoffeeShopDbContext _dbContext;

    public OrderRepository(CoffeeShopDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<Order>> GetAllOrdersAsync()
    {
        return await _dbContext.Orders.ToListAsync();
    }

    public async Task<Order> GetOrderByIdAsync(Guid orderId)
    {
        return await _dbContext.Orders.FindAsync(orderId);
    }

    public async Task AddOrderAsync(Order order)
    {
        _dbContext.Orders.Add(order);
        await _dbContext.SaveChangesAsync();
    }

    public async Task UpdateOrderAsync(Order order)
    {
        _dbContext.Entry(order).State = EntityState.Modified;
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteOrderAsync(Guid orderId)
    {
        var orderToDelete = await _dbContext.Orders.FindAsync(orderId);

        if (orderToDelete != null)
        {
            _dbContext.Orders.Remove(orderToDelete);
            await _dbContext.SaveChangesAsync();
        }
    }
}