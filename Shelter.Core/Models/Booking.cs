namespace Shelter.Core.Models;

public class Booking
{
    public Guid BookingId { get; set; }
    
    public Guid AnimalId { get; set; }
    
    public Animal Animal { get; set; }
    
    public Guid UserId { get; set; }
    
    public User User { get; set; }
    
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
}