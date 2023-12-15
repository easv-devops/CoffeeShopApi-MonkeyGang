namespace Data;

using Microsoft.EntityFrameworkCore;
using Models;

public class CoffeeShopDbContext : DbContext
{
    // ordered by date of creation (oldest first) for debugging purposes
    // at cleanup, sort alphabetically (for readability) ｡◕‿◕｡
    public DbSet<CoffeeCup> CoffeeCups { get; set; }
    public DbSet<Ingredient> Ingredients { get; set; }

    public DbSet<CoffeeCupIngredient> CoffeeCupIngredients { get; set; }

    //public DbSet<Product> Products { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Order> Orders { get; set; }

    public DbSet<OrderDetail> OrderDetails { get; set; }

    //public DbSet<Item> Items { get; set; }
    public DbSet<Cake> Cakes { get; set; }
    public DbSet<Post> Posts { get; set; }

    public DbSet<Store> Stores { get; set; }
    public DbSet<CoffeeBean> CoffeeBeans { get; set; }

    public DbSet<Item> Items { get; set; }

    
    public DbSet<StoreItem> StoreItems { get; set; }

    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<OrderDetail>()
            .HasKey(od => od.OrderDetailId);

        modelBuilder.Entity<OrderDetail>()
            .HasOne(od => od.Item)
            .WithMany()
            .HasForeignKey(od => od.ItemId);

        modelBuilder.Entity<OrderDetail>()
            .HasOne(od => od.Item)
            .WithMany() 
            .HasForeignKey(od => od.ItemId)
            .OnDelete(DeleteBehavior.Restrict);


        modelBuilder.Entity<CoffeeCup>()
            .Property(cc => cc.ItemId)
            .ValueGeneratedOnAdd();
        
      

        modelBuilder.Entity<Cake>()
            .Property(cc => cc.ItemId)
            .ValueGeneratedOnAdd();
        
        
        modelBuilder.Entity<Cake>()
            .HasOne(cake => cake.CoffeeCup)
            .WithMany(cup => cup.Cakes)
            .HasForeignKey(cake => cake.CoffeeCupId)
            .OnDelete(DeleteBehavior.Restrict); // Choose the appropriate behavior

        modelBuilder.Entity<CoffeeCup>()
            .HasMany(cup => cup.Cakes)
            .WithOne(cake => cake.CoffeeCup)
            .HasForeignKey(cake => cake.CoffeeCupId)
            .OnDelete(DeleteBehavior.Restrict); // Choose the appropriate behavior

        
        
        
        
        
    
        modelBuilder.Entity<User>()
            .Property(cc => cc.UserId)
            .ValueGeneratedOnAdd();

        // many-to-many: CoffeeCupIngredient
        modelBuilder.Entity<CoffeeCupIngredient>()
            .HasKey(cci => new { cci.CoffeeCupId, cci.IngredientId });

        modelBuilder.Entity<CoffeeCupIngredient>()
            .HasOne(cci => cci.CoffeeCup)
            .WithMany(cc => cc.CoffeeCupIngredients)
            .HasForeignKey(cci => cci.CoffeeCupId);

        modelBuilder.Entity<CoffeeCupIngredient>()
            .HasOne(cci => cci.Ingredient)
            .WithMany(i => i.CoffeeCupIngredients)
            .HasForeignKey(cci => cci.IngredientId);
        
        
        modelBuilder.Entity<StoreItem>()
            .HasKey(si => new { si.StoreId, si.ItemId });

        modelBuilder.Entity<StoreItem>()
            .HasOne(si => si.Store)
            .WithMany(s => s.StoreItems)
            .HasForeignKey(si => si.StoreId);

        modelBuilder.Entity<StoreItem>()
            .HasOne(si => si.Item)
            .WithMany(i => i.StoreItems)
            .HasForeignKey(si => si.ItemId);


        
        // Configure primary key for UserStore
        modelBuilder.Entity<UserStore>()
            .HasKey(us => new { us.UserId, us.StoreId });

        // Configure the relationships
        modelBuilder.Entity<UserStore>()
            .HasOne(us => us.User)
            .WithMany(u => u.UserStores)
            .HasForeignKey(us => us.UserId);

        modelBuilder.Entity<UserStore>()
            .HasOne(us => us.Store)
            .WithMany(s => s.UserStores)
            .HasForeignKey(us => us.StoreId);
    
        
        
        
        

        /*
         * INGREDIENT - STORE DISABLED
         */


        // one-to-many: Store-Ingredient
        // to avoid cycles in the object graph, we need to disable cascading deletes
        /*
        modelBuilder.Entity<Ingredient>()
            .HasOne(i => i.Store)
            .WithMany(s => s.Ingredients)
            .OnDelete(DeleteBehavior.Restrict);
            */

        /*
        // to avoid cycles in the object graph, we need to disable cascading deletes
        modelBuilder.Entity<Post>()
            .HasOne(p => p.Order)
            .WithMany()
            .HasForeignKey(p => p.OrderId)
            .OnDelete(DeleteBehavior.Restrict); // or DeleteBehavior.NoAction
        */
    }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        String serverName = "EASV-DB4";
        String databaseName = "CSe2022t_t_2_CoffeeShop";
        String userName = "CSe2022t_t_2";
        String password = "CSe2022tT2#";

        

        String connectionString =
            "Server=EASV-DB4,1433;Database=CSe2022t_t_2_CoffeeShop;User Id=CSe2022t_t_2;Password=CSe2022tT2#;TrustServerCertificate=True;";


        optionsBuilder.UseSqlServer(connectionString);
        
        //no idea what this does
        //but I'm afraid to delete it ಠ╭╮ಠ
        optionsBuilder.UseLazyLoadingProxies(); // Disable lazy loading
        
    }
}