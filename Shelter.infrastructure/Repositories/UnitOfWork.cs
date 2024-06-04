using Shelter.Core.Abstraction;

namespace Shelter.infrastructure.Repositories;

public class UnitOfWork(
    ShelterDbContext context,
   
    Lazy<IUserRepository> userRepository,
    Lazy<IAnimalRepository> animalRepository,
    Lazy<IBookingRepository> bookingRepository) : IUnitOfWork
{
    

    public IUserRepository User => userRepository.Value;
    
    public IAnimalRepository Animal => animalRepository.Value;
   

    public IBookingRepository Booking => bookingRepository.Value;
    public async Task SaveAsync() => await  context.SaveChangesAsync();
}