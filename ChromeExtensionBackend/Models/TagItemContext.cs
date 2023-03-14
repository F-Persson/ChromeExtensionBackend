using Microsoft.EntityFrameworkCore;

namespace ChromeExtensionBackend.Models
{
    public class TagItemContext : DbContext
    {
        public TagItemContext(DbContextOptions<TagItemContext> options)
            : base(options)
        {
        }

        public DbSet<TagItem> TagItems { get; set; }
    }
}
