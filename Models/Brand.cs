using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models;

public class Brand
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

    public Guid BrandId { get; set; }

    [Required] public string Name { get; set; }

    // Navigation property for the one-to-many relationship
    public List<Store> Stores { get; set; }
}