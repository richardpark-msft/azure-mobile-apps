using Azure.Mobile.Server;
using BlogServer.Database;
using BlogServer.DataObjects;
using BlogServer.Repositories;
using BlogServer.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace BlogServer.Controllers
{
    [Route("tables/blogcomments")]
    [ApiController]
    public class BlogCommentsController : TableController<BlogComment>
    {
        private readonly IUserService _userService;

        public BlogCommentsController(BlogDbContext context, IUserService userService)
        {
            TableRepository = new BlogCommentsRepository(context);
            _userService = userService;
        }

        public override async Task<BlogComment> PrepareItemForStoreAsync(BlogComment item)
        {
            var user = await _userService.GetOrPopulateUserAsync();
            item.OwnerId = user.Id;
            item.PostedAt = DateTimeOffset.Now;
            return item;
        }

        public override bool IsAuthorized(TableOperation operation, BlogComment item)
        {
            var userId = _userService.GetUserId();

            if (operation == TableOperation.Create && userId is null)
            {
                return false;
            }

            if ((operation == TableOperation.Replace || operation == TableOperation.Delete || operation == TableOperation.Patch) && item.OwnerId != userId)
            {
                return false;
            }

            return true;
        }
    }
}
