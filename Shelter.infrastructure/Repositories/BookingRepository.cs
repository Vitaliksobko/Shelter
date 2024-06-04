using Shelter.Core.Abstraction;
using Shelter.Core.Models;

namespace Shelter.infrastructure.Repositories;

public class BookingRepository(ShelterDbContext context)
    : BaseRepository<Booking>(context), IBookingRepository
{
   
}
