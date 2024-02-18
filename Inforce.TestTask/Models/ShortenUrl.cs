namespace Inforce.TestTask.Models;

public class ShortenerUrl
{
    public Guid Id { get; set; }
    public string LongUrl { get; set; } = null!;

    public string ShortUrl { get; set; } = null!;

    public string Code { get; set; } = null!;

    public DateTime DateOfCreation { get; set; }
}