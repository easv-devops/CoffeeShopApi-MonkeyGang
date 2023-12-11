using System;
using System.Collections.Generic;
using System.Linq;
using Data;
using Microsoft.EntityFrameworkCore;
using Models;
using Repository;


public class CoffeeCupRepository : ICoffeeCupRepository
{
    private readonly CoffeeShopDbContext _dbContext;

    public CoffeeCupRepository(CoffeeShopDbContext context)
    {
        _dbContext = context;
    }

    public async Task<CoffeeCup> GetByIdAsync(Guid id)
    {
        return await _dbContext.CoffeeCups.FindAsync(id);
    }

    public async Task<IEnumerable<CoffeeCup>> GetAllAsync()
    {
        return await _dbContext.CoffeeCups.ToListAsync();
    }

    public async Task AddAsync(CoffeeCup coffeeCup)
    {
        await _dbContext.CoffeeCups.AddAsync(coffeeCup);
        await _dbContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(CoffeeCup coffeeCup)
    {
        _dbContext.CoffeeCups.Update(coffeeCup);
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(CoffeeCup coffeeCup)
    {
        _dbContext.CoffeeCups.Remove(coffeeCup);
        await _dbContext.SaveChangesAsync();
    }
}