using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SampleNLayerProject.Core.Models;
using SampleNLayerProject.Core.Repositories;

namespace SampleNLayerProject.Data.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        // _context => coming from Repository class protected field.
        // _context field is converted to AppDbContext. Because we'll use AppDbContext class as context.
        // so we'll be able to reach tables defined in AppDbContext class.
        private AppDbContext _appDbContext { get => _context as AppDbContext; }
        public ProductRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<Product> GetWithCategoryByIdAsync(int productId)
        {
            return await _appDbContext.Products.Include(x => x.Category).SingleOrDefaultAsync(x => x.Id == productId);
        }
    }
}
