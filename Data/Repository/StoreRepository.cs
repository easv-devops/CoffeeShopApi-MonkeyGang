using Data.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using Models;

namespace Data.Repository;

public class StoreRepository : IStoreRepository
{
    private readonly CoffeeShopDbContext _dbContext;

    public StoreRepository(CoffeeShopDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<Store>> GetAllAsync()
    {
        return await _dbContext.Stores.ToListAsync();
    }

    public async Task<Store> GetByIdAsync(Guid id)
    {
        return await _dbContext.Stores.FindAsync(id);
    }


    public async Task AddAsync(Store store)
    {
        await _dbContext.Stores.AddAsync(store);
        await _dbContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(Store store)
    {
        _dbContext.Entry(store).State = EntityState.Modified;
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var store = await _dbContext.Stores.FindAsync(id);
        if (store != null)
        {
            _dbContext.Stores.Remove(store);
            await _dbContext.SaveChangesAsync();
        }
    }
}