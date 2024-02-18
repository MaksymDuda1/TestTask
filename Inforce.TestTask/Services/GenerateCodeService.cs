using Inforce.TestTask.Abstractions.Services;
using Inforce.TestTask.Data;
using Microsoft.EntityFrameworkCore;

namespace Inforce.TestTask.Services;

public class GenerateCodeService : IGenerateCodeService
{
    public const int ShortLinkLength = 8;
    private const string Alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
    private readonly ApplicationDbContext context;

    private readonly Random random = new();

    public GenerateCodeService(ApplicationDbContext context)
    {
        this.context = context;
    }

    public async Task<string> GenerateUniqueCode()
    {
        var codeChars = new char[ShortLinkLength];

        for (;;)
        {
            for (var i = 0; i < ShortLinkLength; i++)
            {
                var randomIndex = random.Next(Alphabet.Length - 1);

                codeChars[i] = Alphabet[randomIndex];
            }

            var code = new string(codeChars);

            if (!await context.ShortenerUrls.AnyAsync(s => s.Code == code)) 
                return code;
        }
    }

    public async Task<string> GenerateUniqueCode(string code)
    {
        if (!await context.ShortenerUrls.AnyAsync(s => s.Code == code)) 
            return code;
    
        throw new Exception("Short url with this name already exists");
    }
}