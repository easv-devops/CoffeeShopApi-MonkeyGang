
using Repository;
using Models;

namespace Data.Repository;




public class CoffeeCupRepository : ICoffeeCupRepository
{
    private List<CoffeeCup> coffeeCups = new List<CoffeeCup>();

    public CoffeeCup GetCoffeeCupById(Guid cupId)
    {
        return coffeeCups.FirstOrDefault(c => c.Id == cupId);
    }

    public IEnumerable<CoffeeCup> GetAllCoffeeCups()
    {
        return coffeeCups;
    }

    public void AddCoffeeCup(CoffeeCup coffeeCup)
    {
        coffeeCups.Add(coffeeCup);
    }

    public void UpdateCoffeeCup(CoffeeCup coffeeCup)
    {
        // Implementation to update a coffee cup in the database
    }

    public void DeleteCoffeeCup(Guid cupId)
    {
        coffeeCups.RemoveAll(c => c.Id == cupId);
    }
}