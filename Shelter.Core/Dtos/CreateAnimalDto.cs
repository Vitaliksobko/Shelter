using Microsoft.AspNetCore.Http;

namespace Shelter.Core.Dtos;

public class CreateAnimalDto
{
    
    
    public IEnumerable<IFormFile> Images { get; set; }
    public string Name { get; set; }
    
    public int Age { get; set; }
    
    public string Breed { get; set; }
    
    public string Description { get; set; }
}