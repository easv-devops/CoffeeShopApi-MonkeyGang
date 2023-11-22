using Models;

namespace Repository;

public interface ICoffeeRepository
{
    IList<Coffee> GetCoffees();
    Coffee GetCoffee(Guid id);
    bool CoffeeExists(Guid id);
    Coffee UpdateCoffee(Guid id, Coffee coffee);
    void DeleteCoffee(Guid id);
    Coffee CreateCoffee(Coffee coffee);
}