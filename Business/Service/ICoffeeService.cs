using Models;

namespace Service;

public interface ICoffeeService
{
    IList<Coffee> GetCoffees();
    Coffee? GetCoffee(Guid id);
    bool CoffeeExists(Guid id);
    Coffee UpdateCoffee(Guid id, Coffee coffee);
    void DeleteCoffee(Guid id);
    Coffee CreateCoffee(Coffee coffee);
}