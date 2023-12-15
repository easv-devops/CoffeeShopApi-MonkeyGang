using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models;

public class Ingredient
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid IngredientId { get; set; }

    public string Name { get; set; }
    public decimal Price { get; set; }
    //public int StockQuantity { get; set; }

    //public Store Store { get; set; }

    public MeasurementUnit MeasurementUnit { get; set; }

    public virtual List<CoffeeCupIngredient> CoffeeCupIngredients { get; set; }
    
    // I pray to every god i have knowledge of that this dosen't break anything
    public virtual List<CustomCoffeeCupIngredients> CustomCoffeeCupIngredients { get; set; }
    
}