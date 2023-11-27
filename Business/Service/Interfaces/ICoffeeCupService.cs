using Models;
using Presentation.DTOs;

namespace Service;

public interface ICoffeeCupService
{
    CoffeeCupDto GetCoffeeCupById(Guid id);
    List<CoffeeCupDto> GetAllCoffeeCups();
    void AddCoffeeCup(CoffeeCupDto coffeeCupDto);
    void UpdateCoffeeCup(CoffeeCupDto coffeeCupDto);
    void DeleteCoffeeCup(Guid id);
}