namespace Shelter.Core.Abstraction;

public interface IUnitOfWork
{
    IUserRepository User { get; }

    IAnimalRepository Animal { get; }
    
    IBookingRepository Booking { get; }
    
    INewsRepository News { get; }
    Task SaveAsync();
}