using Microsoft.AspNetCore.Mvc;
using Shelter.Application.Abstractions;
using Shelter.Core.Dtos;
using Shelter.Core.Enum;
using Shelter.Core.Models;
using Shop.Core.Dtos;

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
    
    
    [HttpGet("users")]
    public async Task<List<UserDto>> GetAllUsers()
    {
        return await _adminService.GetAllUsers();
    }

    [HttpPut("role")]
    public async Task<IActionResult> ChangeUserRole(ChangeRoleDto request)
    {
        try
        {
            await _adminService.ChangeUserRole(request);

            return Ok();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    
    [HttpDelete("user/{id:guid}")]
    public async Task DeleteUser(Guid id)
    {
        await _adminService.DeleteUser(id);
    }
    
    [HttpDelete("animal/{id:guid}")]
    public async Task DeleteAnimal(Guid id)
    {
        await _adminService.DeleteAnimal(id);
    }
    
    
  
    
    
    [HttpPut("{animalId}/confirm")]
    public async Task<IActionResult> AdoptConfirm(Guid animalId)
    {
        var animal = await _adminService.AdoptConfirm(animalId);
        if (animal == null)
        {
            return NotFound();
        }
        
        return Ok(animal);
    }
    
    [HttpPut("{animalId}/reject")]
    public async Task<IActionResult> AdoptReject(Guid animalId)
    {
        var animal = await _adminService.AdoptReject(animalId);
        if (animal == null)
        {
            return NotFound();
        }
        
        return Ok(animal);
    }

    
   
    
    
}