using System.ComponentModel.DataAnnotations.Schema;

namespace Models;

[Table("Cakes")]
public class Cake : Item
{
    public Cake()
    {
        ItemType = ItemType.Cake;
    }

    public Guid CoffeeCupId { get; set; }
    public CoffeeCup CoffeeCup { get; set; }
}