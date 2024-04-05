namespace DndServer.Application.Interfaces;

public interface IGenericRepository<T>
{
    void Create(T item);
    T? FindById(int id);
    IEnumerable<T> Get();
    IEnumerable<T> Get(Func<T, bool> predicate);
    void Remove(T item);
    void Update(T item);
}