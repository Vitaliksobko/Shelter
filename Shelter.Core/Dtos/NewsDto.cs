namespace Shelter.Core.Dtos;

public class NewsDto
{
    public Guid NewsId { get; set; }
    
    public string Image { get; set; }

    public string Title { get; set; }
    
    public string Content { get; set; }
    
    public string Author { get; set; }
    
    public string Summary { get; set; }
}