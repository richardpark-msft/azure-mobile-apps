using BlogServer.DataObjects;
using Microsoft.EntityFrameworkCore;

namespace BlogServer.Database
{
    public class BlogDbContext : DbContext
    {
        public BlogDbContext(DbContextOptions<BlogDbContext> options) : base(options)
        {
        }

        public DbSet<BlogPost> BlogPosts { get; set; }
    }
}
