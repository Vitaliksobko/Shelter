using Shelter.Core.Dtos;

namespace Shelter.Application.Abstractions;

public interface IQuestionService
{
    Task CreateQuestion(CreateQuestionDto createQuestionDto);
}