using Microsoft.EntityFrameworkCore;
using servicetwo;


public class AppDbContext: DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        
    }
    
    public DbSet<WeatherForecast>? Weather { get; set; }
}