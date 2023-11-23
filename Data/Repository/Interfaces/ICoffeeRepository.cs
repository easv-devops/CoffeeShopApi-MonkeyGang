using Models;

namespace Repository;

public interface ICoffeeCupRepository
{
    CoffeeCup GetCoffeeCupById(Guid cupId);
    IEnumerable<CoffeeCup> GetAllCoffeeCups();
    void AddCoffeeCup(CoffeeCup coffeeCup);
    void UpdateCoffeeCup(CoffeeCup coffeeCup);
    void DeleteCoffeeCup(Guid cupId);
}