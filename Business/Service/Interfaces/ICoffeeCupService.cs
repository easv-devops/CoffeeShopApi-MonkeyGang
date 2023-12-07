using Models;
using Models.DTOs;

namespace Service;

public interface ICoffeeCupService
{
    CoffeeCupDto GetCoffeeCupById(Guid coffeeCupId);
    List<CoffeeCupDto> GetAllCoffeeCups();
    Task<CoffeeCupDto> AddCoffeeCupAsync(CoffeeCupDto coffeeCupDto);
    void UpdateCoffeeCup(CoffeeCupDto coffeeCupDto);
    void DeleteCoffeeCup(Guid coffeeCupId);
}