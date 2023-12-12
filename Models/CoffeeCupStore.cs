namespace Models;

public class CoffeeCupStore
{
    
    public Guid CoffeeCupId { get; set; }
    public CoffeeCup CoffeeCup { get; set; }

    public Guid StoreId { get; set; }
    public Store Store { get; set; }
    
    public List<CoffeeCupStore> CoffeeCupStores { get; set; }


}