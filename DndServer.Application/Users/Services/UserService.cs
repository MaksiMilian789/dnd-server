using DndServer.Application.Interfaces;
using DndServer.Application.Interfaces.Users;
using DndServer.Application.Users.Interfaces;
using DndServer.Domain.Users;

namespace DndServer.Application.Users.Services;

public class UserService : IUserService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository, IUnitOfWork unitOfWork)
    {
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
    }

    public Task<User?> GetByIdAsync(int id) =>
        Task.FromResult(_userRepository.FindById(id));

    public Task<User?> GetByLoginAsync(string login)
    {
        var userList = _userRepository.Get(x => x.Login == login);
        return Task.FromResult(userList.FirstOrDefault());
    }

    public void CreateUser(User user)
    {
        _userRepository.Create(user);
        _unitOfWork.SaveChanges();
    }
}