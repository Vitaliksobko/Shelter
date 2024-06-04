using Shelter.Core.Dtos;
using Shelter.Core.Models;

namespace Shelter.Application.Abstractions;

public interface IAdminService
{
     Task<List<Animal>> GetAllAnimals();

     Task CreateAnimal(CreateAnimalDto createAnimalDto);
}