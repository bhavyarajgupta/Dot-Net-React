using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    // Add the StoreContext class , what is the DbContext class?
    // DbContext is an important class in Entity Framework API. It is a bridge between your domain or entity classes and the database. DbContext is the primary class that is responsible for interacting with the database. It is a combination of the Unit Of Work and Repository patterns.
    // storecontext is a class that inherits from DbContext
    
    public class StoreContext : DbContext
    {
        // Add the constructor
        public StoreContext(DbContextOptions options) : base(options)
        {
        }
 
        // Add the Product entity to the StoreContext
        public DbSet<Product> Products { get; set; }

        // Add the Basket entity to the StoreContext
        public DbSet<Basket> Baskets { get; set; }
        public DbSet<ProductPicture> Pictures { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Define the one-to-many relationship between Product and Picture
            modelBuilder.Entity<ProductPicture>()
                .HasOne(p => p.Product)
                .WithMany(p => p.Pictures)
                .HasForeignKey(p => p.ProductId);

            base.OnModelCreating(modelBuilder);
        }
    }
}


