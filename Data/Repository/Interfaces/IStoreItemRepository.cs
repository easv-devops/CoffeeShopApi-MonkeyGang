using Models;

namespace Data.Repository.Interfaces;

public interface IStoreItemRepository
{
    IEnumerable<Item> GetItemsByStoreId(Guid storeId);
}