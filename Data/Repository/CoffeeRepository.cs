
using Repository;
using Models;

namespace Data.Repository;




public class CoffeeRepository : ICoffeeRepository
{
    private readonly CoffeeShopDbContext _context;

    public CoffeeRepository(CoffeeShopDbContext context)
    {
        _context = context;
    }

    public IList<Coffee> GetCoffees()
    {
        return _context.Coffees.ToList();
    }

    public Coffee GetCoffee(Guid id)
    {
        return _context.Coffees.Find(id);
    }

    public bool CoffeeExists(Guid id)
    {
        return _context.Coffees.Any(x => x.Id == id);
    }

    public Coffee UpdateCoffee(Guid id, Coffee coffee)
    {
        var coffeeToUpdate = GetCoffee(id);
        coffeeToUpdate.Name = coffee.Name;
        coffeeToUpdate.Price = coffee.Price;
        coffeeToUpdate.Description = coffee.Description;
        _context.SaveChanges();
        return coffeeToUpdate;
    }

    public void DeleteCoffee(Guid id)
    {
        _context.Coffees.Remove(GetCoffee(id));
        _context.SaveChanges();
    }

    public Coffee CreateCoffee(Coffee coffee)
    {
        _context.Coffees.Add(coffee);
        _context.SaveChanges();
        return coffee;
    }

 
}