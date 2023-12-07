using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models;

public class Order
{
    
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid OrderID { get; set; }
    public DateTime OrderDate { get; set; }
    
    //inge ide hvorfor vi gør det her???
    public Guid StoreID { get; set; }
    public Store Store { get; set; }
    
    
    //hvorfor har vi både CustomerID og Customer????
    public Guid CustomerID { get; set; }
    public Customer Customer { get; set; }
    public decimal TotalAmount { get; set; }
    public bool IsAccepted { get; set; }
    public List<OrderDetail> OrderDetails { get; set; }
}