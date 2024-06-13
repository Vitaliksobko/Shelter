using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Shelter.Application.Abstractions;
using Shelter.Core.Abstraction;
using Shelter.Core.Dtos;
using Shelter.Core.Enum;
using Shelter.Core.Models;

namespace Shelter.Application.Services;

public class AnimalService(IFileService fileService,IUnitOfWork _unitOfWork, IMapper _mapper) : IAnimalService
{
    
    private readonly Timer _adoptedAnimalCleanupTimer;
    
    
    public async Task<List<Animal>> GetAll()
    {
        var animal = await _unitOfWork.Animal.GetAll();

        return animal;

    }
    
    public async Task<Animal> GetAnimal(AnimalIdDto animalIdDto)
    {
        var animal = await _unitOfWork.Animal.GetSingleByConditionAsync(a => a.AnimalId == animalIdDto.AnimalId);
       
        return animal;
    }

    public async Task<Animal?> BookAnimal(AnimalIdDto animalIdDto, Booking booking)
    {
        var animal = await _unitOfWork.Animal.GetSingleByConditionAsync(a => a.AnimalId == animalIdDto.AnimalId);
        if (animal == null)
        {
            return null;
        }

        // Перевірка накладання прогулянок
        var existingBookings = await _unitOfWork.Booking.GetByConditionsAsync(a => a.AnimalId == animalIdDto.AnimalId);
        foreach (var existingBooking in existingBookings)
        {
            if (booking.StartTime < existingBooking.EndTime && booking.EndTime > existingBooking.StartTime)
            {
                // Нова прогулянка перетинається з існуючою
                return null;
            }
        }

        var createBooking = new Booking
        {
            AnimalId = animalIdDto.AnimalId,
            StartTime = DateTime.SpecifyKind(booking.StartTime, DateTimeKind.Unspecified),
            EndTime = DateTime.SpecifyKind(booking.EndTime, DateTimeKind.Unspecified),
            UserId = booking.UserId
        };

        await _unitOfWork.Booking.InsertAsync(createBooking);
        await _unitOfWork.SaveAsync();

        return animal;
    }
    
    
    public async Task UpdateAnimal(UpdateAnimalDto updateAnimalDto)
    {
        var animalDto = _mapper.Map<AnimalDto>(await _unitOfWork.Animal.GetSingleByConditionAsync(
            a => a.AnimalId == updateAnimalDto.AnimalId));

        animalDto.Name = updateAnimalDto.Name;
        animalDto.Description = updateAnimalDto.Description;
        animalDto.Age = updateAnimalDto.Age;
        animalDto.Breed = updateAnimalDto.Breed;
        
       
        
        
        if (updateAnimalDto.Image == null)
        {
            animalDto.Image = animalDto.Image; 
        }
        else
        {
            animalDto.Image = await fileService.UploadImage(updateAnimalDto.Image);
        }
        

        _unitOfWork.Animal.Update(_mapper.Map<Animal>(animalDto));
        await _unitOfWork.SaveAsync();

        
    }
    
    
    public async Task<Animal> AdoptAnimal(Guid animalId)
    {
        var animal = await _unitOfWork.Animal.GetSingleByConditionAsync(
            a => a.AnimalId == animalId);

        if (animal == null)
        {
            return null;
        }
    
        animal.Status = AnimalStatus.InProcess;
        _unitOfWork.Animal.Update(animal);
        await _unitOfWork.SaveAsync();
       
        return animal;
    }


}