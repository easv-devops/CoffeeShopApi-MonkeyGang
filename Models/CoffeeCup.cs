using System.ComponentModel.DataAnnotations.Schema;

namespace Models;

[Table("CoffeeCups")]
public class CoffeeCup : Item
{
    
    public int Size { get; set; }

    
    
    public List<CoffeeCupIngredient> CoffeeCupIngredients { get; set; }
    public CoffeeCup()
    {
        ItemType = ItemType.CoffeeCup;
    }
    
    
    
}