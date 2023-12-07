using Business.Service;
using Data;
using Data.Repository;
using Data.Repository.Interfaces;
using Repository;
using Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;


namespace Presentation;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        // vi sætter både vores connection string her og i CoffeeShopDbContext.cs
        builder.Services.AddDbContext<CoffeeShopDbContext>();


        builder.Services.AddLogging();
        builder.Services.AddCors();

        ConfigureServices(builder.Services);

        builder.Services.AddControllers();


        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseCors(x => x
            .AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod());
        app.UseRouting();
        //app.UseHttpsRedirection();

        app.UseAuthorization();


        app.MapControllers();

        app.Run();
    }

    public static void ConfigureServices(IServiceCollection services)
    {
        
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "CoffeShopApi", Version = "v1" });
        });
        
        // Add repositories
        services.AddScoped<ICoffeeCupRepository, CoffeeCupRepository>();
        services.AddScoped<IIngredientRepository, IngredientRepository>();
        services.AddScoped<ICoffeeCupIngredientRepository, CoffeeCupIngredientRepository>();

        services.AddScoped<ICustomerRepository, CustomerRepository>();
        services.AddScoped<IOrderRepository, OrderRepository>();
        services.AddScoped<IOrderDetailRepository, OrderDetailRepository>();

        services.AddScoped<IBrandRepository, BrandRepository>();
        services.AddScoped<IStoreRepository, StoreRepository>();
        services.AddScoped<IItemRepository, ItemRepository>();
        
        // Add services
        services.AddScoped<ICoffeeCupService, CoffeeCupService>();
        services.AddScoped<IIngredientService, IngredientService>();
        services.AddScoped<ICoffeeCupIngredientService, CoffeeCupIngredientService>();

        services.AddScoped<ICustomerService, CustomerService>();
        services.AddScoped<IOrderService, OrderService>();
        services.AddScoped<IOrderDetailService, OrderDetailService>();
        
        services.AddScoped<IBrandService, BrandService>();
        services.AddScoped<IStoreService, StoreService>();
        services.AddScoped<IItemService, ItemService>();

        services.AddAutoMapper(typeof(Program));
    }
}