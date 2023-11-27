using Data.Repository.Interfaces;
using Models;

namespace Data.Repository;

public class CoffeeCupIngredientRepository : ICoffeeCupIngredientRepository
{
    private readonly CoffeeShopDbContext _context;

    public CoffeeCupIngredientRepository(CoffeeShopDbContext context)
    {
        _context = context;
    }

    public CoffeeCupIngredient GetCoffeeCupIngredient(Guid coffeeCupId, Guid ingredientId)
    {
        return _context.CoffeeCupIngredients
            .SingleOrDefault(cci => cci.CoffeeCupId == coffeeCupId && cci.IngredientId == ingredientId);
    }

    public List<CoffeeCupIngredient> GetCoffeeCupIngredients(Guid coffeeCupId)
    {
        return _context.CoffeeCupIngredients
            .Where(cci => cci.CoffeeCupId == coffeeCupId)
            .ToList();
    }

    public void AddCoffeeCupIngredient(CoffeeCupIngredient coffeeCupIngredient)
    {
        _context.CoffeeCupIngredients.Add(coffeeCupIngredient);
        _context.SaveChanges();
    }

    public void UpdateCoffeeCupIngredient(CoffeeCupIngredient coffeeCupIngredient)
    {
        _context.CoffeeCupIngredients.Update(coffeeCupIngredient);
        _context.SaveChanges();
    }

    public void DeleteCoffeeCupIngredient(Guid coffeeCupId, Guid ingredientId)
    {
        var coffeeCupIngredient = _context.CoffeeCupIngredients
            .SingleOrDefault(cci => cci.CoffeeCupId == coffeeCupId && cci.IngredientId == ingredientId);

        if (coffeeCupIngredient != null)
        {
            _context.CoffeeCupIngredients.Remove(coffeeCupIngredient);
            _context.SaveChanges();
        }
    }
}