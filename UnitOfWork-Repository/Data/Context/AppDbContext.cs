using Microsoft.EntityFrameworkCore;
using Task.Data.Entities;


namespace Task.Data.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }

    }
}
