using System.ComponentModel.DataAnnotations.Schema;

namespace Models;

[Table("CoffeeCups")]
public class CoffeeCup : Item
{
    public int Size { get; set; }


    public Guid CustomerId { get; set; }

    //todo: update this in other files

    public List<CoffeeCupIngredient> CoffeeCupIngredients { get; set; }
    public List<CoffeeCupStore> CoffeeCupStores { get; set; }

    public CoffeeCup()
    {
        ItemType = ItemType.CoffeeCup;
    }
}