using System.Collections.Generic;
using BlogApi.Models;

namespace BlogApi.Services
{
    public interface IBlogService
    {
        IEnumerable<BlogItem> AllBlogs();
        BlogItem FindBlog(int id);
        void AddBlog(BlogItem blogItem);
        void PutBlogItem(long id, BlogItem item);
        void DeleteBlogItem(long id);
    }
}