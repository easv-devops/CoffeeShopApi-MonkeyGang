using Microsoft.EntityFrameworkCore;
using Models;

namespace Data.Repository;

public class CakeRepository
{
    private readonly CoffeeShopDbContext _context;

    public CakeRepository(CoffeeShopDbContext context)
    {
        _context = context;
    }

    public IEnumerable<Cake> GetAllCakes()
    {
        return _context.Cakes.ToList();
    }

    public Cake GetCakeById(Guid cakeId)
    {
        return _context.Cakes.FirstOrDefault(c => c.ItemId == cakeId);
    }

    public void AddCake(Cake cake)
    {
        _context.Cakes.Add(cake);
        _context.SaveChanges();
    }

    public void UpdateCake(Cake cake)
    {
        _context.Entry(cake).State = EntityState.Modified;
        _context.SaveChanges();
    }

    public void DeleteCake(Guid cakeId)
    {
        var cake = _context.Cakes.Find(cakeId);
        if (cake != null)
        {
            _context.Cakes.Remove(cake);
            _context.SaveChanges();
        }
    }
}