using Models;
using Models.DTOs.Response;

namespace Repository;

public interface ICoffeeCupRepository
{
    Task<CoffeeCup> GetByIdAsync(Guid cupId);
    Task<IEnumerable<CoffeeCup>> GetAllAsync();
    Task AddAsync(CoffeeCup coffeeCup);
    Task UpdateAsync(CoffeeCup coffeeCup);
    Task DeleteAsync(CoffeeCup coffeeCup);
    Task<IEnumerable<Cake>> GetCakesForCoffeeCupAsync(Guid coffeeCupId);
}