using Shelter.Core.Dtos;
using Shelter.Core.Enum;
using Shelter.Core.Models;
using Shop.Core.Dtos;

namespace Shelter.Application.Abstractions;

public interface IAdminService
{
    Task<List<Animal>> GetAllAnimals();

    Task<List<UserDto>> GetAllUsers();

    Task CreateAnimal(CreateAnimalDto createAnimalDto);

    Task ChangeUserRole(ChangeRoleDto changeRoleDto);

    Task DeleteUser(Guid id);

    Task DeleteAnimal(Guid id);

     

    Task<Animal> AdoptConfirm(Guid animalId);

    Task<Animal> AdoptReject(Guid animalId);

    Task DeleteAdoptedAnimalsAfter3Minutes();
}