using DndServer.Domain.Users;

namespace DndServer.Application.Users.Interfaces;

public interface IUserService
{
    Task<User?> GetByIdAsync(int id);
    Task<User?> GetByLoginAsync(string login);
    void CreateUser(User user);
}