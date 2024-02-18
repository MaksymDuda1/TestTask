using Microsoft.AspNetCore.Identity;

namespace Inforce.TestTask.Models;

public class User : IdentityUser<Guid>
{
    public List<ShortenerUrl> ShortenerUrls { get; set; } = new List<ShortenerUrl>();
}