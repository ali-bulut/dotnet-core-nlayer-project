using System;
using System.Threading.Tasks;
using SampleNLayerProject.Core.Models;

namespace SampleNLayerProject.Core.Repositories
{
    public interface ICategoryRepository : IRepository<Category>
    {
        Task<Category> GetWithProductsByIdAsync(int categoryId);
    }
}
