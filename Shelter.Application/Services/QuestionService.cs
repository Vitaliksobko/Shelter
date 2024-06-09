using AutoMapper;
using Shelter.Application.Abstractions;
using Shelter.Core.Abstraction;
using Shelter.Core.Dtos;
using Shelter.Core.Models;

namespace Shelter.Application.Services;

public class QuestionService(IUnitOfWork _unitOfWork, IMapper _mapper) : IQuestionService
{
    public async Task CreateQuestion(CreateQuestionDto createQuestionDto)
    {
        try
        {
            var questionDto = new QuestionDto()
            {
                QuestionId = new Guid(),
                FirstName = createQuestionDto.FirstName,
                SecondName = createQuestionDto.SecondName,
                Email = createQuestionDto.Email,
                PhoneNumber = createQuestionDto.PhoneNumber,
                UserQuestion = createQuestionDto.UserQuestion,
                UserId = createQuestionDto.UserId
             
                
            };
            var question = _mapper.Map<Question>(questionDto);
            await _unitOfWork.Question.InsertAsync(question);
            await _unitOfWork.SaveAsync();
            
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }
}