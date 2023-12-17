﻿// <auto-generated />
using System;
using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Data.Migrations
{
    [DbContext(typeof(CoffeeShopDbContext))]
    partial class CoffeeShopDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Proxies:ChangeTracking", false)
                .HasAnnotation("Proxies:CheckEquality", false)
                .HasAnnotation("Proxies:LazyLoading", true)
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Models.CoffeeCupIngredient", b =>
                {
                    b.Property<Guid>("CoffeeCupId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IngredientId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("CoffeeCupId", "IngredientId");

                    b.HasIndex("IngredientId");

                    b.ToTable("CoffeeCupIngredients");
                });

            modelBuilder.Entity("Models.CustomCoffeeCupIngredients", b =>
                {
                    b.Property<Guid>("CustomCoffeeCupId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IngredientId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("CustomCoffeeCupId", "IngredientId");

                    b.HasIndex("IngredientId");

                    b.ToTable("CustomCoffeeCupIngredients");
                });

            modelBuilder.Entity("Models.Ingredient", b =>
                {
                    b.Property<Guid>("IngredientId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("MeasurementUnit")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("IngredientId");

                    b.ToTable("Ingredients");
                });

            modelBuilder.Entity("Models.Item", b =>
                {
                    b.Property<Guid>("ItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ItemType")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("ItemId");

                    b.ToTable("Items");

                    b.UseTptMappingStrategy();
                });

            modelBuilder.Entity("Models.Order", b =>
                {
                    b.Property<Guid>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsAccepted")
                        .HasColumnType("bit");

                    b.Property<DateTime>("OrderDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2");

                    b.Property<Guid>("StoreId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("TotalAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("OrderId");

                    b.HasIndex("StoreId");

                    b.HasIndex("UserId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("Models.OrderDetail", b =>
                {
                    b.Property<Guid>("OrderDetailId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ItemId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("OrderId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<decimal>("Subtotal")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("OrderDetailId");

                    b.HasIndex("ItemId");

                    b.HasIndex("OrderId");

                    b.ToTable("OrderDetails");
                });

            modelBuilder.Entity("Models.Post", b =>
                {
                    b.Property<Guid>("PostId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CustomerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ItemId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("PostId");

                    b.HasIndex("ItemId");

                    b.HasIndex("UserId");

                    b.ToTable("Posts");
                });

            modelBuilder.Entity("Models.Store", b =>
                {
                    b.Property<Guid>("StoreId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("StoreId");

                    b.ToTable("Stores");
                });

            modelBuilder.Entity("Models.StoreItem", b =>
                {
                    b.Property<Guid>("StoreId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ItemId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("StoreId", "ItemId");

                    b.HasIndex("ItemId");

                    b.ToTable("StoreItems");
                });

            modelBuilder.Entity("Models.User", b =>
                {
                    b.Property<Guid>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsAdmin")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Models.UserStore", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("StoreId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("UserId", "StoreId");

                    b.HasIndex("StoreId");

                    b.ToTable("UserStore");
                });

            modelBuilder.Entity("Models.Cake", b =>
                {
                    b.HasBaseType("Models.Item");

                    b.Property<Guid>("CoffeeCupId")
                        .HasColumnType("uniqueidentifier");

                    b.HasIndex("CoffeeCupId");

                    b.ToTable("Cakes");
                });

            modelBuilder.Entity("Models.CoffeeBean", b =>
                {
                    b.HasBaseType("Models.Item");

                    b.Property<string>("Origin")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoastLevel")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("CoffeeBeans");
                });

            modelBuilder.Entity("Models.CoffeeCup", b =>
                {
                    b.HasBaseType("Models.Item");

                    b.ToTable("CoffeeCups");
                });

            modelBuilder.Entity("Models.CustomCoffeeCup", b =>
                {
                    b.HasBaseType("Models.Item");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasIndex("UserId");

                    b.ToTable("CustomCoffeeCups");
                });

            modelBuilder.Entity("Models.CoffeeCupIngredient", b =>
                {
                    b.HasOne("Models.CoffeeCup", "CoffeeCup")
                        .WithMany("CoffeeCupIngredients")
                        .HasForeignKey("CoffeeCupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Models.Ingredient", "Ingredient")
                        .WithMany("CoffeeCupIngredients")
                        .HasForeignKey("IngredientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CoffeeCup");

                    b.Navigation("Ingredient");
                });

            modelBuilder.Entity("Models.CustomCoffeeCupIngredients", b =>
                {
                    b.HasOne("Models.CustomCoffeeCup", "CustomCoffeeCup")
                        .WithMany("CustomCoffeeCupIngredients")
                        .HasForeignKey("CustomCoffeeCupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Models.Ingredient", "Ingredient")
                        .WithMany("CustomCoffeeCupIngredients")
                        .HasForeignKey("IngredientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CustomCoffeeCup");

                    b.Navigation("Ingredient");
                });

            modelBuilder.Entity("Models.Order", b =>
                {
                    b.HasOne("Models.Store", "Store")
                        .WithMany("Orders")
                        .HasForeignKey("StoreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Models.User", "User")
                        .WithMany("Orders")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Store");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Models.OrderDetail", b =>
                {
                    b.HasOne("Models.Item", "Item")
                        .WithMany()
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Models.Order", "Order")
                        .WithMany("OrderDetails")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Item");

                    b.Navigation("Order");
                });

            modelBuilder.Entity("Models.Post", b =>
                {
                    b.HasOne("Models.Item", "Item")
                        .WithMany()
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Models.User", "User")
                        .WithMany("Posts")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Item");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Models.StoreItem", b =>
                {
                    b.HasOne("Models.Item", "Item")
                        .WithMany("StoreItems")
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Models.Store", "Store")
                        .WithMany("StoreItems")
                        .HasForeignKey("StoreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Item");

                    b.Navigation("Store");
                });

            modelBuilder.Entity("Models.UserStore", b =>
                {
                    b.HasOne("Models.Store", "Store")
                        .WithMany("UserStores")
                        .HasForeignKey("StoreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Models.User", "User")
                        .WithMany("UserStores")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Store");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Models.Cake", b =>
                {
                    b.HasOne("Models.CoffeeCup", "CoffeeCup")
                        .WithMany("Cakes")
                        .HasForeignKey("CoffeeCupId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Models.Item", null)
                        .WithOne()
                        .HasForeignKey("Models.Cake", "ItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CoffeeCup");
                });

            modelBuilder.Entity("Models.CoffeeBean", b =>
                {
                    b.HasOne("Models.Item", null)
                        .WithOne()
                        .HasForeignKey("Models.CoffeeBean", "ItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Models.CoffeeCup", b =>
                {
                    b.HasOne("Models.Item", null)
                        .WithOne()
                        .HasForeignKey("Models.CoffeeCup", "ItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Models.CustomCoffeeCup", b =>
                {
                    b.HasOne("Models.Item", null)
                        .WithOne()
                        .HasForeignKey("Models.CustomCoffeeCup", "ItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Models.Ingredient", b =>
                {
                    b.Navigation("CoffeeCupIngredients");

                    b.Navigation("CustomCoffeeCupIngredients");
                });

            modelBuilder.Entity("Models.Item", b =>
                {
                    b.Navigation("StoreItems");
                });

            modelBuilder.Entity("Models.Order", b =>
                {
                    b.Navigation("OrderDetails");
                });

            modelBuilder.Entity("Models.Store", b =>
                {
                    b.Navigation("Orders");

                    b.Navigation("StoreItems");

                    b.Navigation("UserStores");
                });

            modelBuilder.Entity("Models.User", b =>
                {
                    b.Navigation("Orders");

                    b.Navigation("Posts");

                    b.Navigation("UserStores");
                });

            modelBuilder.Entity("Models.CoffeeCup", b =>
                {
                    b.Navigation("Cakes");

                    b.Navigation("CoffeeCupIngredients");
                });

            modelBuilder.Entity("Models.CustomCoffeeCup", b =>
                {
                    b.Navigation("CustomCoffeeCupIngredients");
                });
#pragma warning restore 612, 618
        }
    }
}
