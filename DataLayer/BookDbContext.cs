using Microsoft.EntityFrameworkCore;
using DemoLibWorld.Entity;

namespace DemoLibWorld.DataLayer
{
    public class BookDbContext : DbContext
    {
        public BookDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<BookEntity> BookCollections { get; set; }
        public DbSet<BookCategory> BookCategories { get; set; }
    }
}
