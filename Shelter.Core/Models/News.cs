using System.Runtime.InteropServices.JavaScript;

namespace Shelter.Core.Models;

public class News
{
    public Guid NewsId { get; set; }
    
    public string Image { get; set; } = string.Empty;

    public string Title { get; set; }
    
    public string Content { get; set; }
    
    public string Author { get; set; }
    
    public string Summary { get; set; }
    
}