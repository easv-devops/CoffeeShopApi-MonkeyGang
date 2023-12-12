using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Models;

[Table("CoffeeCups")]
public class CoffeeCup : Item
{
    public int Size { get; set; }


    public Guid CustomerId { get; set; }

    //todo: update this in other files
    [JsonIgnore]
    public virtual List<CoffeeCupIngredient> CoffeeCupIngredients { get; set; }
    [JsonIgnore]
    public virtual List<CoffeeCupStore> CoffeeCupStores { get; set; }

    public List<Cake> Cakes { get; set; }
    
    public CoffeeCup()
    {
        ItemType = ItemType.CoffeeCup;
    }
}