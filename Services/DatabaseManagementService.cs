using Microsoft.EntityFrameworkCore;

namespace servicetwo.Services;

public class DatabaseManagementService
{
    public static void MigrationInitialization(IApplicationBuilder app)
    {
        using (var serviceScope = app.ApplicationServices.CreateScope())
        {
            serviceScope.ServiceProvider.GetService<AppDbContext>().Database.Migrate();
        }
    }
}