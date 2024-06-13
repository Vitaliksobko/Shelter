using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Shelter.Application.Abstractions;
using Shelter.Core.Abstraction;
using Shelter.Core.Dtos;
using Shelter.Core.Models;
using Shop.Core.Dtos;

namespace Shelter.Application.Services;

public class AdminService(
    IFileService fileService,
    IUnitOfWork _unitOfWork,
    UserManager<User> _userManager,
    IMapper _mapper) : IAdminService
{
    
    public async Task ChangeUserRole(ChangeRoleDto changeRoleDto)
    {
        var user = await _userManager.FindByIdAsync(changeRoleDto.Id.ToString());

        if (user == null)
            throw new Exception("User does not exist");
        
        
        var currentRoles = await _userManager.GetRolesAsync(user);

        if (currentRoles.Contains("Admin"))
        {
            await _userManager.RemoveFromRoleAsync(user, "Admin");
            await _userManager.AddToRoleAsync(user, "User");
        }
        else 
        {
            await _userManager.RemoveFromRoleAsync(user, "User");
            await _userManager.AddToRoleAsync(user, "Admin");
        }

        
        await _userManager.UpdateAsync(user);
    }
    
    public async Task DeleteUser(Guid id)
    {
        await _unitOfWork.User.Delete(id);
        await _unitOfWork.SaveAsync();
    }
    
    public async Task DeleteAnimal(Guid id)
    {
        await _unitOfWork.Animal.Delete(id);
        await _unitOfWork.SaveAsync();
    }
    public async Task<List<Animal>> GetAllAnimals()
    {
        var animal= await _unitOfWork.Animal.GetAll();
        
        return animal;
    }
    
    public async Task<List<UserDto>> GetAllUsers()
    {
        var users= await _unitOfWork.User.GetAll();
        var usersDto = users.Select(_mapper.Map<UserDto>).ToList();

        foreach (var user in usersDto)
        {
            user.IsAdmin = await _userManager.IsInRoleAsync(_mapper.Map<User>(user), "Admin");
        }
        
        return usersDto;
    }
    
    public async Task CreateAnimal(CreateAnimalDto createAnimalDto)
    {
        try
        {
            var animalDto = new AnimalDto()
            {
                AnimalId = new Guid(),
                Name = createAnimalDto.Name,
                Age = createAnimalDto.Age,
                Description = createAnimalDto.Description,
                Breed = createAnimalDto.Breed,
             
                Image = await fileService.UploadImage(createAnimalDto.Image)
            };
            var animal = _mapper.Map<Animal>(animalDto);
            await _unitOfWork.Animal.InsertAsync(animal);
            await _unitOfWork.SaveAsync();

            
            
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }
}