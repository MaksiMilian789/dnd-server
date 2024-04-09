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
}