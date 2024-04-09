using DndServer.Infrastructure.Persistence;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace DndServer.Infrastructure;

public static class MigrateDatabaseExtensions
{
    public static IHost MigrateContext(this IHost host)
    {
        using var scope = host.Services.CreateScope();
        var services = scope.ServiceProvider;
        var loggerFactory = services.GetRequiredService<ILoggerFactory>();
        var logger = loggerFactory.CreateLogger(nameof(MigrateDatabaseExtensions));

        var context = services.GetRequiredService<DataContext>();

        try
        {
            logger.LogInformation("Migrating database");

            context.Migrate();

            logger.LogInformation("Migrated database");
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "An error occurred while migrating the database");
        }

        return host;
    }
}