using DndServer.Domain.Shared.Enums;

namespace DndServer.Application.Worlds.Models;

public class UserRoleDto
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public RoleEnum? Role { get; set; }
}