using Microsoft.EntityFrameworkCore;
using Models;

namespace Data.Repository;

public class CustomerRepository : ICustomerRepository
{
    private readonly CoffeeShopDbContext _dbContext;

    public CustomerRepository(CoffeeShopDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Customer> GetCustomerByIdAsync(Guid id)
    {
        return await _dbContext.Customers.FindAsync(id);
    }

    public async Task<List<Customer>> GetAllCustomersAsync()
    {
        return await _dbContext.Customers.ToListAsync();
    }

    public async Task AddCustomerAsync(Customer customer)
    {
        await _dbContext.Customers.AddAsync(customer);
        await _dbContext.SaveChangesAsync();
    }

    public async Task UpdateCustomerAsync(Customer customer)
    {
        _dbContext.Customers.Update(customer);
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteCustomerAsync(Guid id)
    {
        var customer = await _dbContext.Customers.FindAsync(id);
        if (customer != null)
        {
            _dbContext.Customers.Remove(customer);
            await _dbContext.SaveChangesAsync();
        }
    }
}