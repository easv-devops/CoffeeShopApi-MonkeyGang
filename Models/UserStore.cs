namespace Models;

public class UserStore
{
    public Guid UserId { get; set; }
    public virtual User User { get; set; }

    public Guid StoreId { get; set; }
    public virtual Store Store { get; set; }
}