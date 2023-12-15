using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models;

public class Store
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid StoreId { get; set; }

    [Required] public string Name { get; set; }
    

    public virtual List<Order> Orders { get; set; }
    public virtual List<StoreItem> StoreItems { get; set; }
    public virtual List<UserStore> UserStores { get; set; }
    //public List<Ingredient> Ingredients { get; set; }
}