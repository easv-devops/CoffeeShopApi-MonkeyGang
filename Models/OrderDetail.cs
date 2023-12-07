using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models;

public class OrderDetail
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid OrderDetailId { get; set; }

    public Guid OrderId { get; set; }
    public Order Order { get; set; }
    public int Quantity { get; set; }
    public decimal Subtotal { get; set; }
    
    // Foreign key property
    public Guid ItemId { get; set; }

    // Navigation property
    public Item Item { get; set; }
    
}