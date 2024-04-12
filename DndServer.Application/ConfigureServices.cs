using DndServer.Application.Auth.Interfaces;
using DndServer.Application.Auth.Services;
using DndServer.Application.Characters.Interfaces;
using DndServer.Application.Characters.Services;
using DndServer.Application.Users.Interfaces;
using DndServer.Application.Users.Services;
using DndServer.Domain.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace DndServer.Application;

public static class ConfigureServices
{
    public static IServiceCollection AddApplications(this IServiceCollection services)
    {
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IPasswordHasher<User>, PasswordHasher>();
        services.AddScoped<IJwtService, JwtService>();
        services.AddScoped<ICharacterService, CharacterService>();

        return services;
    }
}