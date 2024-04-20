using System.Linq.Expressions;

namespace DndServer.Application.Interfaces;

public interface IGenericRepository<T>
{
    T Create(T item);
    T? FindById(int id);
    IEnumerable<T> Get();
    IEnumerable<T> Get(Func<T, bool> predicate);
    void Remove(T item);
    void Update(T item);
    IEnumerable<T> GetWithInclude(params Expression<Func<T, object>>[] includeProperties);
    IEnumerable<T> GetWithInclude(Func<T, bool> predicate, params Expression<Func<T, object>>[] includeProperties);
}