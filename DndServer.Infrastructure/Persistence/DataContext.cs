using DndServer.Application.Interfaces;
using DndServer.Domain.Characters;
using DndServer.Domain.Characters.Background;
using DndServer.Domain.Characters.Class;
using DndServer.Domain.Characters.Condition;
using DndServer.Domain.Characters.Inventory;
using DndServer.Domain.Characters.Notes;
using DndServer.Domain.Characters.Race;
using DndServer.Domain.Characters.Skill;
using DndServer.Domain.Characters.Spell;
using DndServer.Domain.Users;
using DndServer.Domain.Worlds;
using DndServer.Infrastructure.Persistence.Configurations.Characters;
using DndServer.Infrastructure.Persistence.Configurations.Characters.Background;
using DndServer.Infrastructure.Persistence.Configurations.Characters.Class;
using DndServer.Infrastructure.Persistence.Configurations.Characters.Condition;
using DndServer.Infrastructure.Persistence.Configurations.Characters.Inventory;
using DndServer.Infrastructure.Persistence.Configurations.Characters.Notes;
using DndServer.Infrastructure.Persistence.Configurations.Characters.Race;
using DndServer.Infrastructure.Persistence.Configurations.Characters.Skill;
using DndServer.Infrastructure.Persistence.Configurations.Characters.Spell;
using DndServer.Infrastructure.Persistence.Configurations.Users;
using DndServer.Infrastructure.Persistence.Configurations.Worlds;
using Microsoft.EntityFrameworkCore;

namespace DndServer.Infrastructure.Persistence;

public class DataContext : DbContext, IUnitOfWork
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
    public DbSet<TrackerUnit> TrackerUnit => Set<TrackerUnit>();
    public DbSet<Wiki> Wiki => Set<Wiki>();
    public DbSet<WikiPage> WikiPage => Set<WikiPage>();
    public DbSet<World> World => Set<World>();

    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }

    void IUnitOfWork.SaveChanges()
    {
        SaveChanges();
    }

    public void Migrate()
    {
        Database.Migrate();
    }

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
        modelBuilder.ApplyConfiguration(new TrackerUnitConfiguration());
        modelBuilder.ApplyConfiguration(new WikiConfiguration());
        modelBuilder.ApplyConfiguration(new WikiPageConfiguration());
        modelBuilder.ApplyConfiguration(new WorldConfiguration());
        modelBuilder.ApplyConfiguration(new WorldLinksConfiguration());
    }
}