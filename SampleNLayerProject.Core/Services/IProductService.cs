using System;
using System.Threading.Tasks;
using SampleNLayerProject.Core.Models;

namespace SampleNLayerProject.Core.Services
{
    public interface IProductService : IService<Product>
    {
        Task<Product> GetWithCategoryByIdAsync(int productId);
    }
}
