using Microsoft.EntityFrameworkCore;
using ShoppintList.Data.Models;

namespace ShoppintList.Data
{
    public class ShoppingListDbContext: DbContext
    {
        public ShoppingListDbContext(DbContextOptions<ShoppingListDbContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; } 
        public DbSet<ProductNote> ProductNotes { get; set; }
    }
}
