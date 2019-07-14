using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogApi.Models;
using BlogApi.Services;
using System;

namespace BlogApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly IBlogService _blogService;

        public BlogController(IBlogService blogService)
        {
            _blogService = blogService;

            if (_blogService.AllBlogs().Count() == 0)
            {
                _blogService.AddBlog(new BlogItem { Title = "First Post" });
            }
        }

        // GET: api/Blog
        [HttpGet]
        public ActionResult<IEnumerable<BlogItem>> GetBlogItems()
        {
            var blogs = _blogService.AllBlogs();
            return blogs.ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<BlogItem> GetBlogItem(int id)
        {
            var blogItem = _blogService.FindBlog(id);

            if (blogItem == null)
            {
                return NotFound();
            }
            return blogItem;
        }

        // POST: api/Blog
        [HttpPost]
        public ActionResult<BlogItem> PostBlogItem(BlogItem item)
        {
            _blogService.AddBlog(item);

            return CreatedAtAction(nameof(GetBlogItem), new BlogItem { Id = item.Id }, item);
        }

        // PUT: api/Blog/5
        [HttpPut("{id}")]
        public IActionResult PutBlogItem(long id, [FromBody]BlogItem item)
        {
            if (id != item.Id)
            {
                return BadRequest();
            }

            try
            {
                _blogService.PutBlogItem(id, item);
            }
            catch (DbUpdateConcurrencyException)
            {
                return NotFound();
            }

            return NoContent();
        }

        // DELETE: api/Blog/5
        [HttpDelete("{id}")]
        public IActionResult DeleteBlogItem(long id)
        {

            try
            {
                _blogService.DeleteBlogItem(id);
            }
            catch 
            {
                return NotFound();
            }

            return NoContent();
        }

    }
}