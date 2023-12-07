using System.ComponentModel.DataAnnotations.Schema;

namespace Models;

[Table("CoffeeCups")]
public class CoffeeCup : Item
{
    
    public int Size { get; set; }

    public Customer Customer { get; set; }
    
    public Guid CustomerId { get; set; }
    
    //todo: update this in other files
    
    public List<CoffeeCupIngredient> CoffeeCupIngredients { get; set; }
    public CoffeeCup()
    {
        ItemType = ItemType.CoffeeCup;
    }
    
    
    
}