using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SampleNLayerProject.Core.Models;

namespace SampleNLayerProject.Data.Seeds
{
    public class CategorySeed : IEntityTypeConfiguration<Category>
    {
        private readonly int[] _ids;
        public CategorySeed(int[] ids)
        {
            _ids = ids;
        }

        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData(
                new Category { Id = _ids[0], Name = "Pen" },
                new Category { Id = _ids[1], Name = "Notebook" }
                );
        }
    }
}
