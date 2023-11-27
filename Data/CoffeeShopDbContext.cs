﻿namespace Data;

using Microsoft.EntityFrameworkCore;
using Models;

public class CoffeeShopDbContext : DbContext
{
    public DbSet<CoffeeCup> CoffeeCup { get; set; }
    public DbSet<Ingredient> Ingredients { get; set; }
    public DbSet<CoffeeCupIngredient> CoffeeCupIngredients { get; set; }
    //public DbSet<Product> Products { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderDetail> OrderDetails { get; set; }
    //public DbSet<Item> Items { get; set; }
    public DbSet<Cake> Cakes { get; set; }
    

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        

        modelBuilder.Entity<OrderDetail>()
            .HasKey(od => od.OrderDetailId);

        modelBuilder.Entity<OrderDetail>()
            .HasOne(od => od.Item)
            .WithMany()
            .HasForeignKey(od => od.ItemId);

/*
        modelBuilder.Entity<CoffeeCup>()
            .HasKey(cc => cc.ItemId);

        modelBuilder.Entity<Cake>()
            .HasKey(c => c.ItemId);
    */

 
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
    }
}