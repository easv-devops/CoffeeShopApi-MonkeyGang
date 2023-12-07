using Data.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using Models;

namespace Data.Repository;

public class ItemRepository : IItemRepository
{
    private readonly CoffeeShopDbContext _dbContext;

    public ItemRepository(CoffeeShopDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<Item>> GetAllItemsAsync()
    {
        return await _dbContext.Items.ToListAsync();
    }

    public async Task<Item> GetItemByIdAsync(Guid id)
    {
        return await _dbContext.Items.FindAsync(id);
    }

    public async Task<IEnumerable<Item>> GetItemsByStoreIdAsync(Guid storeId)
    {
        return await _dbContext.Items
            .Where(item => item.StoreId == storeId)
            .ToListAsync();
    }

    public async Task<Guid> AddItemAsync(Item item)
    {
        await _dbContext.Items.AddAsync(item);
        //await _dbContext.SaveChangesAsync();
        
        // Return the generated ID
        Guid generatedItemId = item.ItemId;

        // Detach the entity from the context
        DetachEntity(item);

        return generatedItemId;
        
    }

    public async Task UpdateItemAsync(Item item)
    {
        _dbContext.Entry(item).State = EntityState.Modified;
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteItemAsync(Guid id)
    {
        var item = await _dbContext.Items.FindAsync(id);
        if (item != null)
        {
            _dbContext.Items.Remove(item);
            await _dbContext.SaveChangesAsync();
        }
    }
    
    
    private void DetachEntity<T>(T entity) where T : class
    {
        var entry = _dbContext.Entry(entity);
        if (entry.State != EntityState.Detached)
        {
            entry.State = EntityState.Detached;
        }
    }
    
}