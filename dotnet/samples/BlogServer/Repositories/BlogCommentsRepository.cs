using Azure.Mobile.Server.Entity;
using BlogServer.DataObjects;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace BlogServer.Repositories
{
    public class BlogCommentsRepository : EntityTableRepository<BlogComment>
    {
        public BlogCommentsRepository(DbContext context) : base(context)
        {
        }

        public override async Task<BlogComment> CreateAsync(BlogComment item, CancellationToken cancellationToken = default)
        {
            var post = await this.Context.Set<BlogPost>().FindAsync(item.PostId);

            if(post != null)
            {
                post.CommentCount++;
            }

            return await base.CreateAsync(item, cancellationToken);
        }

        //TODO: Implement delete so we remove the comment from the CommentCount in the Post.
        public override Task DeleteAsync(string id, CancellationToken cancellationToken = default)
        {
            return base.DeleteAsync(id, cancellationToken);
        }

    }
}
