using Inforce.TestTask.Abstractions.Repositories;
using Inforce.TestTask.Data;
using Inforce.TestTask.Models;
using Microsoft.EntityFrameworkCore;

namespace Inforce.TestTask.Repositories;

public class UrlShorteningRepository : IUrlShorteningRepository
{
    private readonly ApplicationDbContext context;

    public UrlShorteningRepository(ApplicationDbContext context)
    {
        this.context = context;
    }

    public async Task CreateShortenerUrl(ShortenerUrl shortenerUrl)
    {
        var url = await context.ShortenerUrls
            .FirstOrDefaultAsync(u => u.LongUrl == shortenerUrl.LongUrl);

        if (url != null)
            throw new Exception("Url already exists");
        
        await context.ShortenerUrls.AddAsync(shortenerUrl);
        await context.SaveChangesAsync();
    }

    public async Task<List<ShortenerUrl>> GetAll()
    {
        return await context.ShortenerUrls.ToListAsync();
    }

    public async Task<ShortenerUrl> GetById(Guid id)
    {
        var url = await context.ShortenerUrls.FindAsync(id);

        if (url != null)
            return url;

        throw new Exception("Url doesn't exist");
    }

    public async Task Delete(Guid id)
    {
        await context.ShortenerUrls
            .Where(s => s.Id == id)
            .ExecuteDeleteAsync();
    }

    public async Task DeleteAll()
    {
        var urls = await context.ShortenerUrls.ToListAsync();
        context.ShortenerUrls.RemoveRange(urls);
        await context.SaveChangesAsync();
    }

    public async Task<ShortenerUrl> GetShortenedUrl(string code)
    {
        var url = await context.ShortenerUrls.FirstOrDefaultAsync(s => s.Code == code);

        Console.WriteLine(code);
        
        if (url == null)
            throw new Exception("Url doesn't exist");

        return url;
    }
}