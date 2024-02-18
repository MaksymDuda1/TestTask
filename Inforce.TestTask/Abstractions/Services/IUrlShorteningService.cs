using Inforce.TestTask.Dtos;
using Inforce.TestTask.Models;

namespace Inforce.TestTask.Abstractions.Services;

public interface IUrlShorteningService
{
    Task<ShortenerUrl> CreateShortenerUrl(UrlDto request);
    Task<ShortenerUrl> GetShortenedUrl(string code);
    Task<List<ShortenerUrl>> GetAllUrls();
    Task<ShortenerUrl> GetUrlById(Guid id);
    Task DeleteUrlById(Guid id);
    Task DeleteAllUrls();
}