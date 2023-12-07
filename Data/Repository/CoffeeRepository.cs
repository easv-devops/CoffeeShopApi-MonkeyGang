using System;
using System.Collections.Generic;
using System.Linq;
using Data;
using Microsoft.EntityFrameworkCore;
using Models;
using Repository;


public class CoffeeCupRepository : ICoffeeCupRepository
{
    private readonly CoffeeShopDbContext _context;

    public CoffeeCupRepository(CoffeeShopDbContext context)
    {
        _context = context;
    }

    public CoffeeCup GetCoffeeCupById(Guid id)
    {
        return _context.CoffeeCups
            .Include(c => ((Item)c).Description)
            .FirstOrDefault(c => c.ItemId == id);
    }

    public IEnumerable<CoffeeCup> GetAllCoffeeCups()
    {
        return _context.CoffeeCups.ToList();
    }

    public void AddCoffeeCup(CoffeeCup coffeeCup)
    {
        _context.CoffeeCups.Add(coffeeCup);
        _context.SaveChanges();
    }

    public void UpdateCoffeeCup(CoffeeCup coffeeCup)
    {
        _context.Entry(coffeeCup).State = EntityState.Modified;
        _context.SaveChanges();
    }

    public void DeleteCoffeeCup(Guid id)
    {
        var coffeeCupToDelete = _context.CoffeeCups.Find(id);
        if (coffeeCupToDelete != null)
        {
            _context.CoffeeCups.Remove(coffeeCupToDelete);
            _context.SaveChanges();
        }
    }
}