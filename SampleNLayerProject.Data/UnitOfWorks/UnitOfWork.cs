using System;
using System.Threading.Tasks;
using SampleNLayerProject.Core.Repositories;
using SampleNLayerProject.Core.UnitOfWorks;
using SampleNLayerProject.Data.Repositories;

namespace SampleNLayerProject.Data.UnitOfWorks
{
    public class UnitOfWork: IUnitOfWork
    {
        private readonly AppDbContext _context;
        private ProductRepository _productRepository;
        private CategoryRepository _categoryRepository;

        public UnitOfWork(AppDbContext appDbContext)
        {
            _context = appDbContext;
        }

        // set _productRepository to _productRepository if it is not null, else create new instance and set this to _productRepository.
        // then set _productRepository to Products property.
        public IProductRepository Products => _productRepository = _productRepository ?? new ProductRepository(_context);

        public ICategoryRepository Categories => _categoryRepository = _categoryRepository ?? new CategoryRepository(_context);

        public void Commit()
        {
            _context.SaveChanges();
        }

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
