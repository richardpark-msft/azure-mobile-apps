using Microsoft.EntityFrameworkCore;

namespace BlogServer.Database
{
    public static class DbInitializer
    {
        public static void Initialize(BlogDbContext context)
        {
            context.Database.Migrate();
            context.SaveChanges();
        }
    }
}
