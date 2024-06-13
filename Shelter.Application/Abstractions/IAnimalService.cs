using Shelter.Core.Dtos;
using Shelter.Core.Models;

namespace Shelter.Application.Abstractions;

public interface IAnimalService
{
    Task<List<Animal>> GetAll();

    Task<Animal> GetAnimal(AnimalIdDto animalIdDto);

    Task<Animal> BookAnimal(AnimalIdDto animalIdDto, Booking booking);

    Task UpdateAnimal(UpdateAnimalDto updateAnimalDto);
    
    Task<Animal> AdoptAnimal(Guid animalId);
}