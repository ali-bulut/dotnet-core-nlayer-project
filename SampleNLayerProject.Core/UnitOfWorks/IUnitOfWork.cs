using System;
using System.Threading.Tasks;
using SampleNLayerProject.Core.Repositories;

namespace SampleNLayerProject.Core.UnitOfWorks
{
    public interface IUnitOfWork
    {
        IProductRepository Products { get; }
        ICategoryRepository Categories { get; }

        Task CommitAsync();
        void Commit();
    }
}
