using Shelter.Core.Abstraction;
using Shelter.Core.Models;

namespace Shelter.infrastructure.Repositories;

public class QuestionRepository(ShelterDbContext context)
    : BaseRepository<Question>(context), IQuestionRepository
{
    
}