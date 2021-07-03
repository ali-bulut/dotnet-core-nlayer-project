using System;
using System.Threading.Tasks;
using SampleNLayerProject.Core.Models;

namespace SampleNLayerProject.Core.Repositories
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<Product> GetWithCategoryByIdAsync(int productId);
    }
}
