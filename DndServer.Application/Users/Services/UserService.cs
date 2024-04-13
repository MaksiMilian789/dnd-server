using DndServer.Application.Interfaces.Users;
using DndServer.Application.Users.Interfaces;
using DndServer.Domain.Users;

namespace DndServer.Application.Users.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public Task<User?> GetByIdAsync(int id) =>
        Task.FromResult(_userRepository.FindById(id));

    public Task<User?> GetByLoginAsync(string login)
    {
        var userList = _userRepository.Get(x => x.Login == login);
        return Task.FromResult(userList.FirstOrDefault());
    }

    public void CreateUser(User user) =>
        _userRepository.Create(user);
}