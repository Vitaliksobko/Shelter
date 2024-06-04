using Microsoft.AspNetCore.Mvc;
using Shelter.Application.Abstractions;
using Shelter.Core.Dtos;
using Shelter.Core.Models;

namespace Shelter.Api.Controllers;
[ApiController]
[Route("api/admin")]
public class AdminController : Controller
{
   
    private readonly IAdminService _adminService;
   

    public AdminController(IAdminService adminService)
    {
        _adminService = adminService;
       

    }
    
    [HttpGet("animals")]
    public async Task<List<Animal>> GetAllAnimals()
    {
        return await _adminService.GetAllAnimals();
    }
    
    [HttpPost]
    public async Task<ActionResult> CreateAnimal([FromForm] CreateAnimalDto request)
    {
        try
        {
            await _adminService.CreateAnimal(request);

            return Ok();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    
    
}