using System.Collections;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Models;

[Table("CoffeeCups")]
public class CoffeeCup : Item
{
    
    //todo: update this in other files
    [JsonIgnore]
    public virtual ICollection<CoffeeCupIngredient> CoffeeCupIngredients { get; set; }
    [JsonIgnore]
    public virtual ICollection<CoffeeCupStore> CoffeeCupStores { get; set; }

    public List<Cake> Cakes { get; set; }
    
    public CoffeeCup()
    {
        ItemType = ItemType.CoffeeCup;
    }
}