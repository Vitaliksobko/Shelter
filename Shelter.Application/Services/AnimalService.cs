using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Shelter.Application.Abstractions;
using Shelter.Core.Abstraction;
using Shelter.Core.Dtos;
using Shelter.Core.Models;

namespace Shelter.Application.Services;

public class AnimalService(IUnitOfWork _unitOfWork, IMapper _mapper) : IAnimalService
{
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

    public async Task<Animal> BookAnimal(AnimalIdDto animalIdDto, Booking booking)
    {
        var animal = await _unitOfWork.Animal.GetSingleByConditionAsync(a => a.AnimalId == animalIdDto.AnimalId);
        if (animal == null)
        {
           
            return null;
        }

        var createBooking = new Booking()
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


}