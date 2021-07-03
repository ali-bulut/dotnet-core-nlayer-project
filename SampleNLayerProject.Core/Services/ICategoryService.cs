using System;
using System.Threading.Tasks;
using SampleNLayerProject.Core.Models;

namespace SampleNLayerProject.Core.Services
{
    public interface ICategoryService : IService<Category>
    {
        Task<Category> GetWithProductsByIdAsync(int categoryId);
    }
}
