using System;
using System.Threading.Tasks;
using SampleNLayerProject.Core.Models;
using SampleNLayerProject.Core.Repositories;
using SampleNLayerProject.Core.Services;
using SampleNLayerProject.Core.UnitOfWorks;

namespace SampleNLayerProject.Service.Services
{
    public class CategoryService : Service<Category>, ICategoryService
    {
        public CategoryService(IUnitOfWork unitOfWork, IRepository<Category> repository) : base(unitOfWork, repository)
        {
        }

        public async Task<Category> GetWithProductsByIdAsync(int categoryId)
        {
            return await _unitOfWork.Categories.GetWithProductsByIdAsync(categoryId);
        }
    }
}
