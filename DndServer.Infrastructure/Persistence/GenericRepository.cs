using System.Linq.Expressions;
using DndServer.Application.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DndServer.Infrastructure.Persistence;

internal class GenericRepository<T> : IGenericRepository<T> where T : class
{
    private readonly DbContext _context;
    private readonly DbSet<T> _dbSet;

    public GenericRepository(DbContext context)
    {
        _context = context;
        _dbSet = context.Set<T>();
    }

    public IEnumerable<T> Get() =>
        _dbSet.AsNoTracking().ToList();

    public IEnumerable<T> Get(Func<T, bool> predicate) =>
        _dbSet.AsNoTracking().AsEnumerable().Where(predicate).ToList();

    public T? FindById(int id) =>
        _dbSet.Find(id);

    public void Create(T item)
    {
        _dbSet.Add(item);
        _context.SaveChanges();
    }

    public void Update(T item)
    {
        _dbSet.Update(item);
        _context.SaveChanges();
    }

    public void Remove(T item)
    {
        _dbSet.Remove(item);
        _context.SaveChanges();
    }

    public IEnumerable<T> GetWithInclude(params Expression<Func<T, object>>[] includeProperties) =>
        Include(includeProperties).ToList();

    public IEnumerable<T> GetWithInclude(Func<T, bool> predicate,
        params Expression<Func<T, object>>[] includeProperties)
    {
        var query = Include(includeProperties);
        return query.AsEnumerable().Where(predicate).ToList();
    }

    private IQueryable<T> Include(params Expression<Func<T, object>>[] includeProperties)
    {
        var query = _dbSet.AsNoTracking();
        return includeProperties
            .Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
    }
}