using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogApi.Models;

namespace BlogApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly BlogContext _context;

        public BlogController(BlogContext context)
        {
            _context = context;

            if (_context.BlogItems.Count() == 0)
            {
                _context.BlogItems.Add(new BlogItem { Title = "First Post"});
                _context.SaveChanges();
            }
        }

        // GET: api/Blog
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BlogItem>>> GetBlogItems()
        {
            var blogs = await _context.BlogItems.ToListAsync();
            return blogs.ToList();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BlogItem>> GetBlogItem(long id)
        {
            var blogItem = await _context.BlogItems.FindAsync(id);

            if (blogItem == null)
            {
                return NotFound();
            }
            return blogItem;
        }

        // POST: api/Blog
        [HttpPost]
        public async Task<ActionResult<BlogItem>> PostBlogItem(BlogItem item)
        {
            _context.BlogItems.Add(item);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetBlogItem), new BlogItem{ Id = item.Id }, item);
        }

        // PUT: api/Blog/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBlogItem(long id, [FromBody]BlogItem item)
        {
            if (id != item.Id)
            {
                return BadRequest();
            }

            _context.Entry(item).State = EntityState.Modified;

            try
            {
                 await _context.SaveChangesAsync();
            }
            catch(DbUpdateConcurrencyException)
            {
                return NotFound();
            }

            return NoContent();
        }

        // DELETE: api/Blog/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBlogItem(long id)
        {
            var blogItem = await _context.BlogItems.FindAsync(id);
            if (blogItem == null)
            {
                return NotFound();
            }

            _context.BlogItems.Remove(blogItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

    }
}