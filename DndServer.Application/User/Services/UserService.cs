using DndServer.Application.Interfaces.User;
using DndServer.Application.User.Interfaces;

namespace DndServer.Application.User.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public Task<Domain.User.User?> GetByIdAsync(int id) =>
        Task.FromResult(_userRepository.FindById(id));

    public Task<Domain.User.User?> GetByLoginAsync(string login)
    {
        var userList = _userRepository.Get(x => x.Login == login);
        return Task.FromResult(userList.FirstOrDefault());
    }
}