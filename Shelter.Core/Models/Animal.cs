namespace Shelter.Core.Models;

public class Animal
{
    
    public Guid AnimalId { get; set; }
    
   
    
    public string Name { get; set; }
    
    public int Age { get; set; }
    
    public string Breed { get; set; }
    
    public string Description { get; set; }
    
    public IList<string> Images { get; set; }
    
    public List<Booking> Bookings { get; set; }
    
  
}