using Microsoft.AspNetCore.Http;

namespace Shelter.Core.Dtos;

public class UpdateNewsDto
{
    public Guid NewsId { get; set; }
    
    public IFormFile Image { get; set; }

    public string Title { get; set; }
    
    public string Content { get; set; }
    
    public string Author { get; set; }
    
    public string Summary { get; set; }
}