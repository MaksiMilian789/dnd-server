using DndServer.Application.Auth.Interfaces;
using DndServer.Application.Auth.Services;
using DndServer.Application.User.Interfaces;
using DndServer.Application.User.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace DndServer.Application;

public static class ConfigureServices
{
    public static IServiceCollection AddApplications(this IServiceCollection services)
    {
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IPasswordHasher<Domain.User.User>, PasswordHasher>();
        services.AddScoped<IJwtService, JwtService>();

        return services;
    }
}