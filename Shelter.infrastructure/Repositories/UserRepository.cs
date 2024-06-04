
using Shelter.Core.Abstraction;
using Shelter.Core.Models;

namespace Shelter.infrastructure.Repositories;

public class UserRepository(ShelterDbContext context)
    : BaseRepository<User>(context), IUserRepository
{
   
}