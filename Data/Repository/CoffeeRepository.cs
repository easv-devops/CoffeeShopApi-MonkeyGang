using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
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

        {
            
        };
    }

    public async Task<CoffeeCup> GetByIdAsync(Guid id)
    {
        return _dbContext.CoffeeCups
            .Include(cc => cc.CoffeeCupIngredients)
            .ThenInclude(cci => cci.Ingredient)
            .FirstOrDefault(cc => cc.ItemId == id);
    }


    public async Task<IEnumerable<CoffeeCup>> GetAllAsync()
    {
        return await _dbContext.CoffeeCups
            .Include(cc => cc.CoffeeCupIngredients)
            .ThenInclude(cci => cci.Ingredient)
            .ToListAsync();
        
    }
    
    
    public async Task<IEnumerable<CoffeeCup>> GetAllWithIngredientsAsync(string json)
    {
        
        return await _dbContext.CoffeeCups
            .Include(cc => cc.CoffeeCupIngredients)
            .ThenInclude(cci => cci.Ingredient)
            .ToListAsync();
        
        
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