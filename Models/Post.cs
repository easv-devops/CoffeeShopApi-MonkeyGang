using System.ComponentModel.DataAnnotations;

namespace Models;

public class Post
{
    [Key]
    public Guid PostId { get; set; }
    //Todo: research how this exactly works
    DateTime CreatedAt { get; set; } = DateTime.Now;
    public string Text { get; set; }

    // Foreign key to refer to a specific Item in an OrderDetail
    public Guid ItemId { get; set; }
    public Item Item { get; set; }

    // Other properties...

    // Foreign key to refer to the Customer who posted it
    public Guid CustomerId { get; set; }
    public Customer Customer { get; set; }
}