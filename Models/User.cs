using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models;

[Table("Users")]
public class User
{
    
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid UserId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string Address { get; set; }

    private string _passwordHash;

    //BCrypt gemmer salten for os
    public string Password { get; set; }

    public bool IsAdmin { get; set; }

    // Navigation property for the one-to-many relationship
    public virtual List<Order> Orders { get; set; }
    public virtual List<Post> Posts { get; set; }

    // Navigation property for the many-to-many relationship
    public virtual List<UserStore> UserStores { get; set; }
    
    // where do we use this?
    public bool IsPasswordCorrect(string enteredPassword)
    {
        return BCrypt.Net.BCrypt.Verify(enteredPassword, _passwordHash);
    }
    
}