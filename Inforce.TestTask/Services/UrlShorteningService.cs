using Inforce.TestTask.Abstractions.Repositories;
using Inforce.TestTask.Abstractions.Services;
using Inforce.TestTask.Dtos;
using Inforce.TestTask.Models;
using Microsoft.IdentityModel.Tokens;

namespace Inforce.TestTask.Services;

public class UrlShorteningService : IUrlShorteningService
{
    private readonly IGenerateCodeService generateCodeService;
    private readonly IHttpContextAccessor httpContextAccessor;
    private readonly IUrlShorteningRepository urlShorteningRepository;

    public UrlShorteningService(IHttpContextAccessor httpContextAccessor,
        IUrlShorteningRepository urlShorteningRepository,
        IGenerateCodeService generateCodeService)
    {
        this.httpContextAccessor = httpContextAccessor;
        this.urlShorteningRepository = urlShorteningRepository;
        this.generateCodeService = generateCodeService;
    }

    public async Task<List<ShortenerUrl>> GetAllUrls()
    {
        return await urlShorteningRepository.GetAll();
    }

    public async Task<ShortenerUrl> GetUrlById(Guid id)
    {
        return await urlShorteningRepository.GetById(id);
    }

    public async Task<ShortenerUrl> GetShortenedUrl(string code)
    {
        return await urlShorteningRepository.GetShortenedUrl(code);
    }

    public async Task DeleteUrlById(Guid id)
    {
        await urlShorteningRepository.Delete(id);
    }

    public async Task DeleteAllUrls()
    {
        await urlShorteningRepository.DeleteAll();
    }

    public async Task<ShortenerUrl> CreateShortenerUrl(UrlDto request)
    {
        if (!Uri.TryCreate(request.LongUrl, UriKind.Absolute, out _))
            throw new Exception("The specified URL is invalid.");

        var code = "";

        if (request.Code.IsNullOrEmpty())
            code = await generateCodeService.GenerateUniqueCode();
        else
            code = await generateCodeService.GenerateUniqueCode(request.Code);

        var shortenerUrl = new ShortenerUrl
        {
            Id = Guid.NewGuid(),
            LongUrl = request.LongUrl,
            ShortUrl = $"{httpContextAccessor.HttpContext.Request.Scheme}" +
                       $"://{httpContextAccessor.HttpContext.Request.Host}/api/{code}",
            Code = code,
            DateOfCreation = DateTime.UtcNow
        };

        await urlShorteningRepository.CreateShortenerUrl(shortenerUrl);

        return shortenerUrl;
    }
}