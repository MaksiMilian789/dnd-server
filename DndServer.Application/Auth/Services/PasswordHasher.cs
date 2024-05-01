using System.Security.Cryptography;
using System.Text;
using DndServer.Domain.Users;
using Microsoft.AspNetCore.Identity;

namespace DndServer.Application.Auth.Services;

public class PasswordHasher : IPasswordHasher<User>
{
    public string HashPassword(User user, string password)
    {
        var passPhrase = "dnd" + password + "789";
        using var hash = MD5.Create();
        var result = hash.ComputeHash(Encoding.ASCII.GetBytes(passPhrase));
        return result.Aggregate("", (current, b) => current + b);
    }

    public PasswordVerificationResult VerifyHashedPassword(User user, string hashedPassword,
        string providedPassword)
    {
        return hashedPassword == HashPassword(user, providedPassword)
            ? PasswordVerificationResult.Success
            : PasswordVerificationResult.Failed;
    }
}