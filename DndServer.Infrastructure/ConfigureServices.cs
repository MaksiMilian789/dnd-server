using DndServer.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DndServer.Infrastructure;

public static class ConfigureServices
{
    public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("default");
        Console.WriteLine(connectionString);
        services
            .AddDbContext<DataContext>(
                options => { options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)); }
            );
        Console.WriteLine(connectionString);

        //services.AddScoped<IProjectRepository, ProjectRepository>();

        return services;
    }
}