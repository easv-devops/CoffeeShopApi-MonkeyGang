namespace Data;

using Microsoft.EntityFrameworkCore;

using Models;


public class CoffeeShopDbContext : DbContext
{
    public DbSet<Coffee> Coffees { get; set; }
    public DbSet<Ingredient> Ingredients { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        
        String serverName = "EASV-DB4";
        String databaseName = "CSe2022t_t_2_3rdSemesterExamProject";
        String userName = "CSe2022t_t_2";
        String password = "CSe2022tT2#";

        

        String connectionString = "Server=EASV-DB4,1433;Database=CSe2022t_t_2_3rdSemesterExamProject;User Id=CSe2022t_t_2;Password=CSe2022tT2#;TrustServerCertificate=True;";

        
        optionsBuilder.UseSqlServer(connectionString);
        
        
    }
}