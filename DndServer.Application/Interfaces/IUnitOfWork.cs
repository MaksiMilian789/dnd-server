namespace DndServer.Application.Interfaces;

public interface IUnitOfWork
{
    public void SaveChanges();
}