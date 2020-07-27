using Azure.Mobile.Server;
using Azure.Mobile.Server.Entity;
using BlogServer.Database;
using BlogServer.DataObjects;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Web;

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

        public override BlogPost PrepareItemForStore(BlogPost item)
        {
            item.OwnerId = this.User.GetNameIdentifierId();
            return item;
        }

        public override bool IsAuthorized(TableOperation operation, BlogPost item)
        {
            var userId = this.User.GetNameIdentifierId();

            if(operation == TableOperation.Create && userId is null)
            {
                return false;
            }

            if((operation == TableOperation.Replace || operation == TableOperation.Delete || operation == TableOperation.Patch) && item.OwnerId != userId)
            {
                return false;
            }

            return true;
        }

    }
}
