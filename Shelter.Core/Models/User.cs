using Microsoft.AspNetCore.Identity;

namespace Shelter.Core.Models;

public class User : IdentityUser<Guid>
{
    public string FirstName { get; set; } = string.Empty;

    public string SecondName { get; set; } = string.Empty;

    public DateTime RegistrationDate { get; set; }
    
    public DateTime EditDate { get; set; }
    
    public DateTime DeleteDate { get; set; }

    public List<Booking> Bookings { get; set; }
}