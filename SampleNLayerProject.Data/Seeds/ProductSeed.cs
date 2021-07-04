using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SampleNLayerProject.Core.Models;

namespace SampleNLayerProject.Data.Seeds
{
    public class ProductSeed : IEntityTypeConfiguration<Product>
    {
        private readonly int[] _ids;
        public ProductSeed(int[] ids)
        {
            _ids = ids;
        }

        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasData(
                // if we insert default data to db, we have to define id. 
                new Product { Id = 1, Name = "Ballpoint Pen", Price = 12.50m, Stock = 100, CategoryId = _ids[0] },
                new Product { Id = 2, Name = "Rollerball Pen", Price = 16.50m, Stock = 200, CategoryId = _ids[0] },
                new Product { Id = 3, Name = "Gel Pen", Price = 21.70m, Stock = 500, CategoryId = _ids[0] },
                new Product { Id = 4, Name = "Small Size Notebook", Price = 5.50m, Stock = 200, CategoryId = _ids[1] },
                new Product { Id = 5, Name = "Medium Size Notebook", Price = 7.50m, Stock = 300, CategoryId = _ids[1] },
                new Product { Id = 6, Name = "Large Size Notebook", Price = 9.50m, Stock = 400, CategoryId = _ids[1] }
                );
        }
    }
}
