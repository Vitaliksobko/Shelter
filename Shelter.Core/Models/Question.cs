namespace Shelter.Core.Models;

public class Question
{
    public Guid QuestionId { get; set; }
    
    public string FirstName { get; set; } = string.Empty;

    public string SecondName { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public string PhoneNumber { get; set; } = string.Empty;

    public string UserQuestion { get; set; }  
    
    public Guid UserId { get; set; }
    
    
}