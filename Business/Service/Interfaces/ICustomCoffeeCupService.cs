using Models.DTOs;
using Models.DTOs.Create;
using Models.DTOs.Response;

namespace Service;

public interface ICustomCoffeeCupService
{
    Task<CustomCoffeeCupResponseDto> GetCustomCoffeeCupByIdAsync(Guid id);
    Task<IEnumerable<CustomCoffeeCupResponseDto>> GetAllCustomCoffeeCupsAsync();
    Task<Guid> CreateCustomCoffeeCupAsync(CustomCoffeeCupCreateDto createDto);
    Task<CustomCoffeeCupResponseDto> UpdateCustomCoffeeCupAsync(Guid id, CustomCoffeeCupDto updateDto);
    Task<bool> DeleteCustomCoffeeCupAsync(Guid id);
}