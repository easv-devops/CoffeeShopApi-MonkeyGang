using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models;

public class Post
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid PostId { get; set; }


    public string Title { get; set; }
    public string Text { get; set; }

    public Guid UserId { get; set; }
    public virtual User User { get; set; }
}