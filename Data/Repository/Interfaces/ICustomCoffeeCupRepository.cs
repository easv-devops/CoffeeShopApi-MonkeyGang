using Models;

namespace Data.Repository.Interfaces;

public interface ICustomCoffeeCupRepository
{
    Task<CustomCoffeeCup> GetCustomCoffeeCupByIdAsync(Guid id);
    Task<IEnumerable<CustomCoffeeCup>> GetAllCustomCoffeeCupsAsync();
    Task<Guid> CreateCustomCoffeeCupAsync(CustomCoffeeCup customCoffeeCup);
    Task UpdateCustomCoffeeCupAsync(CustomCoffeeCup customCoffeeCup);
    Task<bool> DeleteCustomCoffeeCupAsync(Guid id);
}