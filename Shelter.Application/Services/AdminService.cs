using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Shelter.Application.Abstractions;
using Shelter.Core.Abstraction;
using Shelter.Core.Dtos;
using Shelter.Core.Models;

namespace Shelter.Application.Services;

public class AdminService(IFileService fileService, IUnitOfWork _unitOfWork, UserManager<User> _userManager, IMapper _mapper) : IAdminService
{
    public async Task<List<Animal>> GetAllAnimals()
    {
        var animal= await _unitOfWork.Animal.GetAll();
        
        return animal;
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