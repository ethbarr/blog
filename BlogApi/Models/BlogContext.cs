using Microsoft.EntityFrameworkCore;

namespace BlogApi.Models
{
    public class BlogContext : DbContext
    {
        public BlogContext(DbContextOptions<BlogContext> options) : base(options)
        {
            
        } 

        public DbSet<BlogItem> BlogItems { get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            new BlogMap(modelBuilder.Entity<BlogItem>());
        }
    }

}