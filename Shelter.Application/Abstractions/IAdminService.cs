using Shelter.Core.Dtos;
using Shelter.Core.Models;
using Shop.Core.Dtos;

namespace Shelter.Application.Abstractions;

public interface IAdminService
{
     Task<List<Animal>> GetAllAnimals();

     Task<List<User>> GetAllUsers();

     Task CreateAnimal(CreateAnimalDto createAnimalDto);

     Task ChangeUserRole(ChangeRoleDto changeRoleDto);

     Task DeleteUser(Guid id);

     Task DeleteAnimal(Guid id);
}