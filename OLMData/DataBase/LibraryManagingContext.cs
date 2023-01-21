using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OLMServer.OLMData.Structures;

namespace OLMServer.OLMData.DataBase
{
    public class LibraryManagingContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<BookSerie> BookSeries { get; set; }
        public DbSet<Rent> Rents { get; set; }

        public DbSet<StockAsset> StockAssets { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<Comment> Comments { get; set; }

        public DbSet<BookLocation> BookLocations { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Mail> Mails { get; set; }
        public DbSet<PhoneNumber> PhoneNumbers { get; set; }

        public DbSet<List<int>> intLists { get; set; }


        public string Dbpath { get; }


        public LibraryManagingContext()
        {
            Dbpath = "./DataDase.db";
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options) => options.UseSqlite($"Data Source = {Dbpath}");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<List<int>>(
                    eb =>
                    {
                        eb.Ignore("IntList");
                        eb.HasNoKey();
                    });
        }
    }
}
