using System.ComponentModel.DataAnnotations.Schema;

namespace Models;

[Table("CoffeeCups")]
public class CoffeeCup : Item
{

 
    //public Guid CoffeeCupId { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    
    public int size { get; set; }

    //navigation properties
    public List<CoffeeCupIngredient> CoffeeCupIngredients { get; set; }
    //public ICollection<OrderDetail> OrderDetails { get; set; }    
    public CoffeeCup()
    {
        ItemType = ItemType.CoffeeCup;
    }
    
    
}