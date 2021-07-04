using System;
using Microsoft.EntityFrameworkCore;
using SampleNLayerProject.Core.Models;
using SampleNLayerProject.Data.Configurations;

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
        }
    }
}
