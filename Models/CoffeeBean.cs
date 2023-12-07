using System.ComponentModel.DataAnnotations.Schema;

namespace Models;

[Table("CoffeeBeans")]
public class CoffeeBean : Item
{
    public string Origin { get; set; }
    public string RoastLevel { get; set; }


    public CoffeeBean()
    {
        ItemType = ItemType.CoffeeBean;
    }
}