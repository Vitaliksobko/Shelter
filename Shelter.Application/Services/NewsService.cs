using AutoMapper;
using Shelter.Application.Abstractions;
using Shelter.Core.Abstraction;
using Shelter.Core.Dtos;
using Shelter.Core.Models;

namespace Shelter.Application.Services;

public class NewsService(IFileService fileService, IUnitOfWork _unitOfWork, IMapper _mapper) : INewsService
{
    public async Task<List<News>> GetAll()
    {
        var news = await _unitOfWork.News.GetAll();

        return news;

    }

    public async Task DeleteNews(Guid id)
    {
        await _unitOfWork.News.Delete(id);
        await _unitOfWork.SaveAsync();
    }
    public async Task CreateNews(CreateNewsDto createNewsDto)
    {
        try
        {
            var NewsDto = new NewsDto()
            {
                NewsId = new Guid(),
                Content = createNewsDto.Content,
                Title = createNewsDto.Title,
                Summary = createNewsDto.Summary,
                Author = createNewsDto.Author,
                Image = await fileService.UploadImage(createNewsDto.Image)
            };
            var news = _mapper.Map<News>(NewsDto);
            await _unitOfWork.News.InsertAsync(news);
            await _unitOfWork.SaveAsync();

            
            
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }
}