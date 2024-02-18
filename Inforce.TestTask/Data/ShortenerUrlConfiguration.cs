using Inforce.TestTask.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inforce.TestTask.Data;

public class ShortenerUrlConfiguration : IEntityTypeConfiguration<ShortenerUrl>
{
    public void Configure(EntityTypeBuilder<ShortenerUrl> builder)
    {
        builder.HasIndex(s => s.Code).IsUnique();
    }
}