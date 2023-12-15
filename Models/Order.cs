using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models;

public class Order
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid OrderId { get; set; }

    public Guid StoreId { get; set; }
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public DateTime OrderDate { get; set; }

    //inge ide hvorfor vi gør det her???
    public virtual Store Store { get; set; }


    public Guid UserId { get; set; }
    public virtual User User { get; set; }
    public decimal TotalAmount { get; set; }
    public bool IsAccepted { get; set; }
    public virtual List<OrderDetail> OrderDetails { get; set; }
}