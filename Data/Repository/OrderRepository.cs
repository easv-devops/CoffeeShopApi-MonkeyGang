using Microsoft.EntityFrameworkCore;
using Models;

namespace Data.Repository;

public class OrderRepository : IOrderRepository
{
    private readonly CoffeeShopDbContext _dbContext;

    public OrderRepository(CoffeeShopDbContext dbContext)
    {
        _dbContext = dbContext;
        // turn off proxy creation
        _dbContext.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
    }

    public List<Order> GetAllOrdersAsync()
    {
        
        
        return  _dbContext.Orders.Include(o => o.OrderDetails).ToList();
    }

    public async Task<Order> GetOrderByIdAsync(Guid orderId)
    {
        return await _dbContext.Orders
            .AsNoTracking()
            
            .Include(o => o.Store)
            .Include(o => o.OrderDetails)
            .FirstOrDefaultAsync(o => o.OrderId == orderId);
        
    }

    public async Task<Guid> AddOrderAsync(Order order)
    {
        // Optionally, set any other properties or perform additional operations before adding
        order.OrderId = Guid.NewGuid();

        _dbContext.Orders.Add(order);
        await _dbContext.SaveChangesAsync();

        return order.OrderId;
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