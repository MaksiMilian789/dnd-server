using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Identity;

namespace DndServer.Application.Auth.Services;

public class PasswordHasher : IPasswordHasher<Domain.User.User>
{
    public string HashPassword(Domain.User.User user, string password)
    {
        var passPhrase = "dnd" + password + "789";
        using var hash = MD5.Create();
        var result = hash.ComputeHash(Encoding.ASCII.GetBytes(passPhrase));
        return result.Aggregate("", (current, b) => current + b);
    }

    public PasswordVerificationResult VerifyHashedPassword(Domain.User.User user, string hashedPassword,
        string providedPassword) =>
        hashedPassword == HashPassword(user, providedPassword)
            ? PasswordVerificationResult.Success
            : PasswordVerificationResult.Failed;
}