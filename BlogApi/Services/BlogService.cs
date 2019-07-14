using System.Collections.Generic;
using System.Linq;
using BlogApi.Models;
using Microsoft.EntityFrameworkCore;

namespace BlogApi.Services
{
    public class BlogService : IBlogService
    {
        private readonly BlogContext _blogContext;

        public BlogService(BlogContext blogContext)
        {
            _blogContext = blogContext;
        }

        public IEnumerable<BlogItem> AllBlogs()
        {
            return _blogContext.BlogItems
                        .OrderBy(x => x.TimeStamp)
                        .ToList();
        }

        public BlogItem FindBlog(int id)
        {
            return _blogContext.BlogItems
                        .FirstOrDefault(x => x.Id == id);
        }

        public void AddBlog(BlogItem blogItem)
        {
            _blogContext.Add(blogItem);
        }


        public void PutBlogItem(long id, BlogItem item)
        {
            _blogContext.Entry(item).State = EntityState.Modified;
            _blogContext.SaveChangesAsync();
        }

        public void DeleteBlogItem(long id)
        {
            var blogItem = _blogContext.BlogItems.FindAsync(id).Result;

            _blogContext.BlogItems.Remove(blogItem);
            _blogContext.SaveChangesAsync();
        }
    }
}