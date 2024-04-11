namespace DndServer.Application.User.Interfaces;

public interface IUserService
{
    Task<Domain.User.User?> GetByIdAsync(int id);

    Task<Domain.User.User?> GetByLoginAsync(string login);
}