using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Models;

public class Item
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid ItemId { get; set; }

    public ItemType ItemType { get; set; } // Enum representing the type of item
    // Common properties for all items...

    public string Name { get; set; }
    public decimal Price { get; set; }
    public string Description { get; set; }
    public string Image { get; set; }

    public virtual List<StoreItem> StoreItems { get; set; }
    

}