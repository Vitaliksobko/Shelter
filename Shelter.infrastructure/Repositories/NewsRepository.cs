using Shelter.Core.Abstraction;
using Shelter.Core.Models;

namespace Shelter.infrastructure.Repositories;

public class NewsRepository(ShelterDbContext context)
    : BaseRepository<News>(context), INewsRepository
{
   
}