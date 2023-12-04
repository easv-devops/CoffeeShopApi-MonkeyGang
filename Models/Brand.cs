using System.ComponentModel.DataAnnotations;

namespace Models;

public class Brand
{
    [Key]
    public Guid BrandId { get; set; }

    [Required]
    public string Name { get; set; }

    // Navigation property for the one-to-many relationship
    public List<Store> Stores { get; set; }
}