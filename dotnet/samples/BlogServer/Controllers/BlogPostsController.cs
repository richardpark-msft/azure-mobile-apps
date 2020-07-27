using Azure.Mobile.Server;
using Azure.Mobile.Server.Entity;
using BlogServer.Database;
using BlogServer.DataObjects;
using Microsoft.AspNetCore.Mvc;

namespace BlogServer.Controllers
{
    [Route("tables/blog_posts")]
    [ApiController]
    public class BlogPostsController : TableController<BlogPost>
    {
        public BlogPostsController(BlogDbContext context)
        {
            TableRepository = new EntityTableRepository<BlogPost>(context);
        }
    }
}
