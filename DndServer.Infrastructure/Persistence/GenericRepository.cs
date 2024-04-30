using System.Linq.Expressions;
using DndServer.Application.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DndServer.Infrastructure.Persistence;

internal class GenericRepository<T> : IGenericRepository<T> where T : class
{
    private readonly DbSet<T> _dbSet;
    private readonly DbContext _context;

    public GenericRepository(DbContext context)
    {
        _context = context;
        _dbSet = context.Set<T>();
    }

    public IEnumerable<T> Get()
    {
        return _dbSet.ToList();
    }

    public IEnumerable<T> Get(Func<T, bool> predicate)
    {
        return _dbSet.AsEnumerable().Where(predicate).ToList();
    }

    public T? FindById(int id)
    {
        return _dbSet.Find(id);
    }

    public void Update(T item)
    {
        _dbSet.Update(item);
    }

    public void Attach(T item)
    {
        _context.Attach(item);
    }

    public void Remove(T item)
    {
        _dbSet.Remove(item);
    }

    public T Create(T item)
    {
        var res = _dbSet.Add(item);
        return res.Entity;
    }

    public IEnumerable<T> GetWithInclude(params Expression<Func<T, object>>[] includeProperties)
    {
        return Include(includeProperties).ToList();
    }

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