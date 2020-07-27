using Azure.Mobile.Server;
using Azure.Mobile.Server.Entity;
using BlogServer.Database;
using BlogServer.DataObjects;
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
            // Using Object Id as UserId since this ID uniquely identifies the user across applications.
            // Two different applications signing in the same user will receive the same value in the oid claim.
            // GetNameIdentifierId() returns the sub claim that it is unique to a particular application ID. 
            // Therefore, if a single user signs into two different apps using two different client IDs, 
            // those apps will receive two different values for the subject claim.
            item.OwnerId = this.User.GetObjectId();
            return item;
        }

        public override bool IsAuthorized(TableOperation operation, BlogPost item)
        {
            var userId = this.User.GetObjectId();

            if (operation == TableOperation.Create && userId is null)
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
