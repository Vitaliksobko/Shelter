using Microsoft.AspNetCore.Mvc;
using Shelter.Application.Abstractions;
using Shelter.Core.Dtos;
using Shelter.Core.Models;

namespace Shelter.Api.Controllers;

[Route("/api/animal")]
public class AnimalController : Controller
{
    private readonly IAnimalService _animalService;
    

    public AnimalController(IAnimalService animalService)
    {
        _animalService = animalService;

    }

    [HttpGet]
    public async Task<List<Animal>> GetAll()
    {
        return await _animalService.GetAll();
    }

    [HttpGet("{animalId:guid}")]
    public async Task<IActionResult> GetAnimalById(AnimalIdDto animalIdDto)
    {
        var animal = await _animalService.GetAnimal(animalIdDto);
        return Ok(animal);
    } 

    [HttpPost("{animalId:guid}/book")]
    public async Task<IActionResult> BookAnimal(AnimalIdDto animalIdDto, [FromBody] Booking booking)
    {
        var animal = await _animalService.BookAnimal(animalIdDto, booking);
        if (animal == null)
        {
            return NotFound();
        }

        return Ok(animal);
    }
    
    [HttpPut]
    public async Task<IActionResult> UpdateAnimal([FromForm] UpdateAnimalDto request)
    {
        try
        {
            await _animalService.UpdateAnimal(request);

            return Ok();
        }
        catch(Exception e)
        {
            return BadRequest(e.Message);
            
        }
    }
  
}