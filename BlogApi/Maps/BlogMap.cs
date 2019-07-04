using BlogApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class BlogMap
{
    public BlogMap(EntityTypeBuilder<BlogItem> entityBuilder)
    {
        entityBuilder.HasKey(x => x.Id);
        entityBuilder.ToTable("blog");

        entityBuilder.Property(x => x.Id).HasColumnName("id");
        entityBuilder.Property(x => x.Title).HasColumnName("title");
        entityBuilder.Property(x => x.Body).HasColumnName("body");
        entityBuilder.Property(x => x.TimeStamp).HasColumnName("timestamp");
    }
}