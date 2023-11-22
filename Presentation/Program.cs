using Data.Repository;
using Data;
using Repository;
using Service;

using Microsoft.EntityFrameworkCore;



namespace Presentation;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        // vi sætter både vores connection string her og i CoffeeShopDbContext.cs
        builder.Services.AddDbContext<CoffeeShopDbContext>(opts =>
            opts.UseSqlServer("Server=EASV-DB4,1433;Database=CSe2022t_t_2_3rdSemesterExamProject;User Id=CSe2022t_t_2;Password=CSe2022tT2#;TrustedServerCertificate=True;"));
        builder.Services.AddAutoMapper(typeof(Program));
        builder.Services.AddLogging();
        builder.Services.AddCors();
        
        // Services
        builder.Services.AddScoped<ICoffeeService, CoffeeService>();
        //builder.Services.AddScoped<IIngredientService, IngredientService>();
        
        //Repositories
        builder.Services.AddScoped<ICoffeeRepository, CoffeeRepository>();
        //builder.Services.AddScoped<IIngredientRepository, IngredientRepository>();
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
}


