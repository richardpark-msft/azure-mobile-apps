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
        public DbSet<PostComment> PostComments { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Bookmark> Bookmarks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<PostComment>()
                .HasOne<BlogPost>()
                .WithMany()
                .HasForeignKey(comment => comment.PostId);

            modelBuilder.Entity<PostComment>()
               .HasOne<User>()
               .WithMany()
               .HasForeignKey(comment => comment.OwnerId);

            modelBuilder.Entity<BlogPost>()
                .HasOne<User>()
                .WithMany()
                .HasForeignKey(post => post.OwnerId);

            modelBuilder.Entity<Bookmark>()
                .HasOne<User>()
                .WithMany()
                .HasForeignKey(bookmark => bookmark.UserId);

            modelBuilder.Entity<Bookmark>()
                .HasOne<BlogPost>()
                .WithMany()
                .HasForeignKey(bookmark => bookmark.PostId);
        }
    }
}
