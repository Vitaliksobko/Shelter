using Microsoft.AspNetCore.Identity;

namespace Shelter.Core.Models;

public class User : IdentityUser<Guid>
{
    public string FirstName { get; set; } = string.Empty;

    public string SecondName { get; set; } = string.Empty;

    public List<Booking> Bookings { get; set; }
}