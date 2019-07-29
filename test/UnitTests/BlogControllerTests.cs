using Xunit;
using Moq;
using BlogApi.Controllers;
using BlogApi.Services;
using System.Collections.Generic;
using BlogApi.Models;
using GenFu;
using System.Linq;

namespace UnitTests {
    public class BlogControllerTests{

        public IEnumerable<BlogItem> GetFakeData()
        {
            var i = 1;
            var blogs = A.ListOf<BlogItem>(26);
            blogs.ForEach(x => x.Id = i++);
            return blogs.Select(_ => _);
        }

        [Fact]
        public void CanAssertTrue() {
            Assert.True(true, "My first test");
        }

        [Fact]
        public void controllerTest()
        {
            var service = new Mock<IBlogService>();
            var blogs = GetFakeData();
            service.Setup(x => x.AllBlogs()).Returns(blogs);

            var controller = new BlogController(service.Object);

            var results = controller.GetBlogItems();

            var count = results.Count();

            Assert.Equal(26, count);
        }

        [Fact]
        public void TestName()
        {
            var service = new Mock<IBlogService>();
            
            var blogs = GetFakeData();
            var firstBlog = blogs.First();
            service.Setup(x => x.FindBlog(1)).Returns(firstBlog);

            var controller = new BlogController(service.Object);

            var result = controller.GetBlogItem(1);
            var person = result.Value;

            Assert.Equal(1, person.Id);
        }
    }

    
}