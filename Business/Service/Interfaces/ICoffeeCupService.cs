using Models;
using Models.DTOs;
using Models.DTOs.Create;

namespace Service;

public interface ICoffeeCupService
{
    Task<CoffeeCup> GetCoffeeCupByIdAsync(Guid coffeeCupId);
    Task<IEnumerable<CoffeeCup>> GetAllCoffeeCupsAsync();
    Task<Guid> AddCoffeeCupAsync(CoffeeCup coffeeCup);
    Task UpdateCoffeeCupAsync(CoffeeCup coffeeCup);
    Task<bool> DeleteCoffeeCupAsync(Guid coffeeCupId);
}