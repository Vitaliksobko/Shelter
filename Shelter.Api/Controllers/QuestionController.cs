using Microsoft.AspNetCore.Mvc;
using Shelter.Application.Abstractions;
using Shelter.Core.Dtos;

namespace Shelter.Api.Controllers;


[ApiController]
[Route("/api/question")]
public class QuestionController: Controller
{
    private readonly IQuestionService _questionService;
   

    public QuestionController(IQuestionService questionService)
    {
        _questionService = questionService;
       

    } 
    
    [HttpPost]
    public async Task<IActionResult> AskQuestion([FromForm] CreateQuestionDto request)
    {
        try
        {
            await _questionService.CreateQuestion(request);

            return Ok();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
  
}