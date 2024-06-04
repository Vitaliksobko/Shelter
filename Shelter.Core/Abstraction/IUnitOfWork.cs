namespace Shelter.Core.Abstraction;

public interface IUnitOfWork
{
    IUserRepository User { get; }

    IAnimalRepository Animal { get; }
    
    IBookingRepository Booking { get; }
    Task SaveAsync();
}