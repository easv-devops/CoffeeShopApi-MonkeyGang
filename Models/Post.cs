using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models;

public class Post
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid PostId { get; set; }

    //Todo: research how this exactly works
    //DateTime CreatedAt { get; set; }
    public string Title { get; set; }
    public string Text { get; set; }

    
    //kunne være based at bruge en item, 
    

    // Other properties...
    // Foreign key to refer to the Customer who posted it
    public Guid UserId { get; set; }
    public virtual User User { get; set; }
}