using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concretes
{
    public class MutluMarketDb:DbContext
    {
       

        public MutluMarketDb(DbContextOptions<MutluMarketDb> options) : base(options) { }
        
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .HasMany(c => c.products)
                .WithOne(p => p.Category)
                .HasForeignKey(p => p.CategoryId);

            modelBuilder.Entity<Cart>()
               .HasOne(c => c.Product)
               .WithMany()
               .HasForeignKey(c => c.ProductId);

            modelBuilder.Entity<User>()
            .HasIndex(u => u.Email)
            .IsUnique();


            base.OnModelCreating(modelBuilder);
        }


        


    }
}
