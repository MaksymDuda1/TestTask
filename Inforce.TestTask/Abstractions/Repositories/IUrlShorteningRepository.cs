using Inforce.TestTask.Models;

namespace Inforce.TestTask.Abstractions.Repositories;

public interface IUrlShorteningRepository
{
    Task CreateShortenerUrl(ShortenerUrl shortenerUrl);
    Task<ShortenerUrl> GetShortenedUrl(string code);
    Task<List<ShortenerUrl>> GetAll();
    Task<ShortenerUrl> GetById(Guid id);
    Task<string> GetCreatorId(Guid id);
    Task Delete(Guid id);
    Task DeleteAll();
}