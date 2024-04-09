using DndServer.Domain.Character;
using DndServer.Domain.Character.Background;
using DndServer.Domain.Character.Class;
using DndServer.Domain.Character.Condition;
using DndServer.Domain.Character.Inventory;
using DndServer.Domain.Character.Note;
using DndServer.Domain.Character.Race;
using DndServer.Domain.Character.Skill;
using DndServer.Domain.Character.Spell;
using DndServer.Domain.User;
using DndServer.Domain.World;
using DndServer.Infrastructure.Persistence.Configurations.Character;
using DndServer.Infrastructure.Persistence.Configurations.Character.Background;
using DndServer.Infrastructure.Persistence.Configurations.Character.Class;
using DndServer.Infrastructure.Persistence.Configurations.Character.Condition;
using DndServer.Infrastructure.Persistence.Configurations.Character.Inventory;
using DndServer.Infrastructure.Persistence.Configurations.Character.Note;
using DndServer.Infrastructure.Persistence.Configurations.Character.Race;
using DndServer.Infrastructure.Persistence.Configurations.Character.Skill;
using DndServer.Infrastructure.Persistence.Configurations.Character.Spell;
using DndServer.Infrastructure.Persistence.Configurations.User;
using DndServer.Infrastructure.Persistence.Configurations.World;
using Microsoft.EntityFrameworkCore;

namespace DndServer.Infrastructure.Persistence;

public class DataContext : DbContext
{
    public DbSet<User> User => Set<User>();
    public DbSet<BackgroundInstance> BackgroundInstance => Set<BackgroundInstance>();
    public DbSet<BackgroundTemplate> BackgroundTemplate => Set<BackgroundTemplate>();
    public DbSet<ClassInstance> ClassInstance => Set<ClassInstance>();
    public DbSet<ClassTemplate> ClassTemplate => Set<ClassTemplate>();
    public DbSet<Conditions> Conditions => Set<Conditions>();
    public DbSet<ObjectInstance> ObjectInstance => Set<ObjectInstance>();
    public DbSet<ObjectTemplate> ObjectTemplate => Set<ObjectTemplate>();
    public DbSet<Note> Note => Set<Note>();
    public DbSet<RaceInstance> RaceInstance => Set<RaceInstance>();
    public DbSet<RaceTemplate> RaceTemplate => Set<RaceTemplate>();
    public DbSet<SkillInstance> SkillInstance => Set<SkillInstance>();
    public DbSet<SkillTemplate> SkillTemplate => Set<SkillTemplate>();
    public DbSet<SpellInstance> SpellInstance => Set<SpellInstance>();
    public DbSet<SpellTemplate> SpellTemplate => Set<SpellTemplate>();
    public DbSet<Character> Character => Set<Character>();
    public DbSet<Tracker> Tracker => Set<Tracker>();
    public DbSet<Wiki> Wiki => Set<Wiki>();
    public DbSet<WikiPage> WikiPage => Set<WikiPage>();
    public DbSet<World> World => Set<World>();

    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }

    public void Migrate() =>
        Database.Migrate();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new BackgroundInstanceConfiguration());
        modelBuilder.ApplyConfiguration(new BackgroundTemplateConfiguration());
        modelBuilder.ApplyConfiguration(new ClassInstanceConfiguration());
        modelBuilder.ApplyConfiguration(new ClassTemplateConfiguration());
        modelBuilder.ApplyConfiguration(new ConditionsConfiguration());
        modelBuilder.ApplyConfiguration(new ObjectInstanceConfiguration());
        modelBuilder.ApplyConfiguration(new ObjectTemplateConfiguration());
        modelBuilder.ApplyConfiguration(new NoteConfiguration());
        modelBuilder.ApplyConfiguration(new RaceInstanceConfiguration());
        modelBuilder.ApplyConfiguration(new RaceTemplateConfiguration());
        modelBuilder.ApplyConfiguration(new SkillInstanceConfiguration());
        modelBuilder.ApplyConfiguration(new SkillTemplateConfiguration());
        modelBuilder.ApplyConfiguration(new SpellInstanceConfiguration());
        modelBuilder.ApplyConfiguration(new SpellTemplateConfiguration());
        modelBuilder.ApplyConfiguration(new CharacterConfiguration());
        modelBuilder.ApplyConfiguration(new UserConfiguration());
        modelBuilder.ApplyConfiguration(new TrackerConfiguration());
        modelBuilder.ApplyConfiguration(new WikiConfiguration());
        modelBuilder.ApplyConfiguration(new WikiPageConfiguration());
        modelBuilder.ApplyConfiguration(new WorldConfiguration());
        modelBuilder.ApplyConfiguration(new WorldLinksConfiguration());
    }
}