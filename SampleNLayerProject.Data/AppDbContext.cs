using System;
using Microsoft.EntityFrameworkCore;
using SampleNLayerProject.Core.Models;
using SampleNLayerProject.Data.Configurations;
using SampleNLayerProject.Data.Seeds;

namespace SampleNLayerProject.Data
{
    // AppDbContext refers db.
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        // defining db tables
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }


        // method that works before table creation operation on db.
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());

            modelBuilder.ApplyConfiguration(new ProductSeed(new int[] { 1, 2 }));
            modelBuilder.ApplyConfiguration(new CategorySeed(new int[] { 1, 2 }));
        }
    }
}
