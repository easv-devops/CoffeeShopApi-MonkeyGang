using System.ComponentModel.DataAnnotations;

namespace Models;

public class Item
{
    
    [Key]
    public Guid ItemId { get; set; }
    public ItemType ItemType { get; set; } // Enum representing the type of item
    // Common properties for all items...


}