using Microsoft.AspNetCore.Mvc;
using Shelter.Application.Abstractions;
using Shelter.Core.Dtos;
using Shelter.Core.Models;

namespace Shelter.Api.Controllers;
[ApiController]
[Route("api/news")]
public class NewsController: Controller
{
    private readonly INewsService _newsService;
   

    public NewsController(INewsService newsService)
    {
        _newsService = newsService;
       

    } 
    
    [HttpGet]
    public async Task<List<News>> GetAll()
    {
        return await _newsService.GetAll();
    }
    
     
    [HttpPost]
    public async Task<ActionResult> CreateNews([FromForm] CreateNewsDto request)
    {
        try
        {
            await _newsService.CreateNews(request);

            return Ok();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    
    [HttpDelete("product/{id:guid}")]
    public async Task DeleteNews(Guid id)
    {
        await _newsService.DeleteNews(id);
    }

   

}