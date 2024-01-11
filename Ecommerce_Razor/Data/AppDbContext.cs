using Ecommerce_Razor.Models;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce_Razor.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Category> categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category
                {
                    Id = 1,
                    Name = "William",
                    DisplayOrder = 1
                },

            new Category
            {
                Id = 3,
                Name = "Cirilla",
                DisplayOrder = 4
            },

            new Category
            {
                Id = 2,
                Name = "Yenn",
                DisplayOrder = 3
            });


        }
    }
}

