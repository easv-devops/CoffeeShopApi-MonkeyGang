namespace Data;

using Microsoft.EntityFrameworkCore;

using Models;


public class CoffeeShopDbContext : DbContext
{
    public DbSet<CoffeeCup> CoffeeCup { get; set; }
    public DbSet<Ingredient> Ingredients { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderDetail> OrderDetails { get; set; }
    
    
    
    
    

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        
        String serverName = "EASV-DB4";
        String databaseName = "CSe2022t_t_2_CoffeeShop";
        String userName = "CSe2022t_t_2";
        String password = "CSe2022tT2#";

        

        String connectionString = "Server=EASV-DB4,1433;Database=CSe2022t_t_2_CoffeeShop;User Id=CSe2022t_t_2;Password=CSe2022tT2#;TrustServerCertificate=True;";

        
        optionsBuilder.UseSqlServer(connectionString);
        
        
    }
}