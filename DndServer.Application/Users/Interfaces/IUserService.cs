using DndServer.Application.Users.Models;
using DndServer.Domain.Users;

namespace DndServer.Application.Users.Interfaces;

public interface IUserService
{
    Task<UserDto> GetByLogin(string login);
    Task<User?> GetDomainUserByLogin(string login);
    Task Registration(RegistrationDto dto);
    void CreateUser(User user);
}