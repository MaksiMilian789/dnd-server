using DndServer.Domain.User;
using Microsoft.EntityFrameworkCore;

namespace DndServer.Infrastructure.Persistence;

public class DataContext : DbContext
{
    public DbSet<User> User => Set<User>();

    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }
}