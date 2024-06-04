namespace Shelter.Core.Models;

public class Animal
{
    
    public Guid AnimalId { get; set; }
    
    public string Image { get; set; }
    
    public string Name { get; set; }
    
    public int Age { get; set; }
    
    public string Breed { get; set; }
    
    public string Description { get; set; }
    
    public List<Booking> Bookings { get; set; }
    
    public DateTime? RegistrationDate { get; set; }
    
    public DateTime? EditDate { get; set; }
    
    public DateTime? DeleteDate { get; set; }
}