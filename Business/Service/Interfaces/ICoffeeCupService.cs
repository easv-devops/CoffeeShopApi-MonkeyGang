using Models;
using Models.DTOs;
using Models.DTOs.Create;
using Models.DTOs.Response;

namespace Service;

public interface ICoffeeCupService
{
    Task<CoffeeCupResponseDto> GetCoffeeCupByIdAsync(Guid coffeeCupId);
    Task<IEnumerable<CoffeeCupResponseDto>> GetAllCoffeeCupsAsync();
    Task<Guid> AddCoffeeCupAsync(CreateCoffeeCupDto createDto);
    Task UpdateCoffeeCupAsync(Guid coffeeCupId, CoffeeCupResponseDto updateDto);
    Task<bool> DeleteCoffeeCupAsync(Guid coffeeCupId);
    Task<List<CakeResponseDto>> GetCakesForCoffeeCupAsync(Guid coffeeCupId);
}