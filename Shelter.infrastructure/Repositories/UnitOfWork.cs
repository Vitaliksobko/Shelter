using Shelter.Core.Abstraction;

namespace Shelter.infrastructure.Repositories;

public class UnitOfWork(
    ShelterDbContext context,
   
    Lazy<IUserRepository> userRepository,
    Lazy<IAnimalRepository> animalRepository,
    Lazy<IBookingRepository> bookingRepository,
    Lazy<INewsRepository> newsRepository,
    Lazy<IQuestionRepository> questionRepository) : IUnitOfWork
{
    

    public IUserRepository User => userRepository.Value;
    
    public IAnimalRepository Animal => animalRepository.Value;

    public INewsRepository News => newsRepository.Value;

    public IBookingRepository Booking => bookingRepository.Value;
    
    public IQuestionRepository Question => questionRepository.Value;
    public async Task SaveAsync() => await  context.SaveChangesAsync();
}