using Shelter.Core.Dtos;
using Shelter.Core.Models;

namespace Shelter.Application.Abstractions;

public interface INewsService
{
    Task<List<News>> GetAll();

    Task CreateNews(CreateNewsDto createNewsDto);

    Task DeleteNews(Guid id);

    Task<News> GetNewsById(Guid NewsId);

    Task UpdateNews(UpdateNewsDto updateNewsDto);
}