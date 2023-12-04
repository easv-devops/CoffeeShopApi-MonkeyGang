using System.ComponentModel.DataAnnotations;

namespace Models;

public class Store
{
    [Key]
    public Guid StoreId { get; set; }

    [Required]
    public string Name { get; set; }

    // Foreign key property
    public Guid BrandId { get; set; }

    // Navigation property
    public Brand Brand { get; set; }
    public List<Order> Orders { get; set; }
    public List<Ingredient> Ingredients { get; set; }
}