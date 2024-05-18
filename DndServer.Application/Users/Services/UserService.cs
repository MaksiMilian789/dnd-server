using DndServer.Application.Interfaces;
using DndServer.Application.Interfaces.Users;
using DndServer.Application.Resources;
using DndServer.Application.Users.Interfaces;
using DndServer.Application.Users.Models;
using DndServer.Domain.Users;
using Microsoft.AspNetCore.Identity;

namespace DndServer.Application.Users.Services;

public class UserService : IUserService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IUserRepository _userRepository;
    private readonly IPasswordHasher<User> _hasher;

    public UserService(IUserRepository userRepository, IUnitOfWork unitOfWork, IPasswordHasher<User> hasher)
    {
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
        _hasher = hasher;
    }

    public Task<UserDto> GetByLogin(string login)
    {
        var user = _userRepository.Get(x => x.Login == login).FirstOrDefault();
        if (user == null)
        {
            throw new Exception(Errors.UserNotFound);
        }

        var userDto = new UserDto
        {
            Id = user.Id,
            Login = user.Login
        };
        return Task.FromResult(userDto);
    }

    public Task<User?> GetDomainUserByLogin(string login)
    {
        var user = _userRepository.Get(x => x.Login == login).FirstOrDefault();
        return Task.FromResult(user);
    }

    public Task Registration(RegistrationDto dto)
    {
        var user = _userRepository.Get(x => x.Login == dto.Login).FirstOrDefault();
        if (user != null)
        {
            throw new Exception(Errors.UserNotFound);
        }

        var newUser = new User(dto.Login, "");
        var hashedPassword = _hasher!.HashPassword(newUser, dto.Password);
        newUser.PasswordHash = hashedPassword;

        CreateUser(newUser);

        return Task.CompletedTask;
    }

    public void CreateUser(User user)
    {
        _userRepository.Create(user);
        _unitOfWork.SaveChanges();
    }
}