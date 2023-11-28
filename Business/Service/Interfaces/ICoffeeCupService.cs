using Models;
using Models.DTOs;

namespace Service;

public interface ICoffeeCupService
{
    CoffeeCupDto GetCoffeeCupById(Guid coffeeCupId);
    List<CoffeeCupDto> GetAllCoffeeCups();
    void AddCoffeeCup(CoffeeCupDto coffeeCupDto);
    void UpdateCoffeeCup(CoffeeCupDto coffeeCupDto);
    void DeleteCoffeeCup(Guid coffeeCupId);
}