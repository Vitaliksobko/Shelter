using System.Reflection.Metadata.Ecma335;

namespace Shelter.Core.Dtos;

public class UserDto
{
    public Guid Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string SecondName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public bool IsAdmin { get; set; }
}