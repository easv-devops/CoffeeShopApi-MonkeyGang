using Data.Repository.Interfaces;
using Models;

namespace Data.Repository;

public class StoreItemRepository : IStoreItemRepository
{
    private readonly CoffeeShopDbContext _dbContext;

    public StoreItemRepository(CoffeeShopDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public IEnumerable<Item> GetItemsByStoreId(Guid storeId)
    {
        var items = _dbContext.StoreItems
            .Where(si => si.StoreId == storeId)
            .Select(si => si.Item)
            .ToList();

        if (items == null)
        {
            Console.WriteLine("No items found for store ID: {0}", storeId);

            return null;
        }
        

        return items;
    }
}