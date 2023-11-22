
using Models;
using Repository;

namespace Service;

public class CoffeeService : ICoffeeService
{
    private ICoffeeRepository _coffeeRepository;

    public CoffeeService(ICoffeeRepository coffeeRepository)
    {
        _coffeeRepository = coffeeRepository;
    }
    
    public IList<Coffee> GetCoffees()
    {
        return _coffeeRepository.GetCoffees();
    }

    public Coffee GetCoffee(Guid id)
    {
        return _coffeeRepository.GetCoffee(id);
    }

    public bool CoffeeExists(Guid id)
    {
        return _coffeeRepository.CoffeeExists(id);
    }

    public Coffee UpdateCoffee(Guid id, Coffee coffee)
    {
        return _coffeeRepository.UpdateCoffee(id, coffee);
    }

    public void DeleteCoffee(Guid id)
    {
        _coffeeRepository.DeleteCoffee(id);
    }

    public Coffee CreateCoffee(Coffee coffee)
    {
        return _coffeeRepository.CreateCoffee(coffee);
    }


}