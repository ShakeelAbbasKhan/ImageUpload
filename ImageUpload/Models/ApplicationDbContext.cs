using Microsoft.EntityFrameworkCore;

namespace ImageUpload.Models
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<ImageInfo> Images { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
    }
}
