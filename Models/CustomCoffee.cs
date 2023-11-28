using System.ComponentModel.DataAnnotations.Schema;

namespace Models;

[Table("CustomCoffeeCups")]
public class CustomCoffeeCup : CoffeeCup
{
    // Additional properties specific to custom coffee cups
    public Guid UserId { get; set; }
    public Customer User { get; set; } // Reference to the user who created it
}