using DndServer.Application.Interfaces.Characters;
using DndServer.Application.Interfaces.Characters.Background;
using DndServer.Application.Interfaces.Characters.Class;
using DndServer.Application.Interfaces.Characters.Condition;
using DndServer.Application.Interfaces.Characters.Inventory;
using DndServer.Application.Interfaces.Characters.Notes;
using DndServer.Application.Interfaces.Characters.Race;
using DndServer.Application.Interfaces.Characters.Skill;
using DndServer.Application.Interfaces.Characters.Spell;
using DndServer.Application.Interfaces.Users;
using DndServer.Application.Interfaces.Worlds;
using DndServer.Infrastructure.Persistence;
using DndServer.Infrastructure.Persistence.Repositories.Characters;
using DndServer.Infrastructure.Persistence.Repositories.Characters.Background;
using DndServer.Infrastructure.Persistence.Repositories.Characters.Class;
using DndServer.Infrastructure.Persistence.Repositories.Characters.Condition;
using DndServer.Infrastructure.Persistence.Repositories.Characters.Inventory;
using DndServer.Infrastructure.Persistence.Repositories.Characters.Notes;
using DndServer.Infrastructure.Persistence.Repositories.Characters.Race;
using DndServer.Infrastructure.Persistence.Repositories.Characters.Skill;
using DndServer.Infrastructure.Persistence.Repositories.Characters.Spell;
using DndServer.Infrastructure.Persistence.Repositories.Users;
using DndServer.Infrastructure.Persistence.Repositories.Worlds;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DndServer.Infrastructure;

public static class ConfigureServices
{
    public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("default");
        services
            .AddDbContext<DataContext>(
                options => { options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)); }
            );

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