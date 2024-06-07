using Microsoft.AspNetCore.Http;

namespace Shelter.Application.Abstractions;

public interface IFileService
{
    Task<string> UploadImage(IFormFile file);

    Task<List<string>> UploadImages(IEnumerable<IFormFile> files);
}