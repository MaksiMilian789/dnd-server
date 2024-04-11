using DndServer.Application.Interfaces.Character;
using DndServer.Application.Interfaces.Character.Background;
using DndServer.Application.Interfaces.Character.Class;
using DndServer.Application.Interfaces.Character.Condition;
using DndServer.Application.Interfaces.Character.Inventory;
using DndServer.Application.Interfaces.Character.Note;
using DndServer.Application.Interfaces.Character.Race;
using DndServer.Application.Interfaces.Character.Skill;
using DndServer.Application.Interfaces.Character.Spell;
using DndServer.Application.Interfaces.User;
using DndServer.Application.Interfaces.World;
using DndServer.Infrastructure.Persistence;
using DndServer.Infrastructure.Persistence.Repositories.Character;
using DndServer.Infrastructure.Persistence.Repositories.Character.Background;
using DndServer.Infrastructure.Persistence.Repositories.Character.Class;
using DndServer.Infrastructure.Persistence.Repositories.Character.Condition;
using DndServer.Infrastructure.Persistence.Repositories.Character.Inventory;
using DndServer.Infrastructure.Persistence.Repositories.Character.Note;
using DndServer.Infrastructure.Persistence.Repositories.Character.Race;
using DndServer.Infrastructure.Persistence.Repositories.Character.Skill;
using DndServer.Infrastructure.Persistence.Repositories.Character.Spell;
using DndServer.Infrastructure.Persistence.Repositories.User;
using DndServer.Infrastructure.Persistence.Repositories.World;
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

        services.AddScoped<IWorldRepository, WorldRepository>();
        services.AddScoped<IWorldLinksRepository, WorldLinksRepository>();
        services.AddScoped<IWikiRepository, WikiRepository>();
        services.AddScoped<IWikiPageRepository, WikiPageRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<ICharacterRepository, CharacterRepository>();
        services.AddScoped<IBackgroundInstanceRepository, BackgroundInstanceRepository>();
        services.AddScoped<IBackgroundTemplateRepository, BackgroundTemplateRepository>();
        services.AddScoped<IClassInstanceRepository, ClassInstanceRepository>();
        services.AddScoped<IClassTemplateRepository, ClassTemplateRepository>();
        services.AddScoped<IConditionsRepository, ConditionsRepository>();
        services.AddScoped<IObjectInstanceRepository, ObjectInstanceRepository>();
        services.AddScoped<IObjectTemplateRepository, ObjectTemplateRepository>();
        services.AddScoped<INoteRepository, NoteRepository>();
        services.AddScoped<IRaceInstanceRepository, RaceInstanceRepository>();
        services.AddScoped<IRaceTemplateRepository, RaceTemplateRepository>();
        services.AddScoped<ISkillInstanceRepository, SkillInstanceRepository>();
        services.AddScoped<ISkillTemplateRepository, SkillTemplateRepository>();
        services.AddScoped<ISpellInstanceRepository, SpellInstanceRepository>();
        services.AddScoped<ISpellTemplateRepository, SpellTemplateRepository>();

        return services;
    }
}