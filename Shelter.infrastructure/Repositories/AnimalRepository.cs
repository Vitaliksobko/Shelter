using Shelter.Core.Abstraction;
using Shelter.Core.Models;

namespace Shelter.infrastructure.Repositories;

public class AnimalRepository(ShelterDbContext context)
    : BaseRepository<Animal>(context), IAnimalRepository
{
   
}