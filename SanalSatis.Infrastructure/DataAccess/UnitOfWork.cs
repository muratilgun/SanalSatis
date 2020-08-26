using System;
using System.Collections;
using System.Threading.Tasks;
using SanalSatis.Kernel.Entities;
using SanalSatis.Kernel.Interfaces;

namespace SanalSatis.Infrastructure.DataAccess
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ProjectContext _projectContext;
        private Hashtable _repositories;
        public UnitOfWork(ProjectContext projectContext)
        {
            _projectContext = projectContext;
        }

        public async Task<int> Complete()
        {
            return await _projectContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            _projectContext.Dispose();
        }

        public IGenericRepository<TEntity> Repository<TEntity>() where TEntity : BaseEntity
        {
            if(_repositories == null) _repositories = new Hashtable();

            var type = typeof(TEntity).Name;

            if (!_repositories.ContainsKey(type))
            {
                var repositoryType = typeof(GenericRepository<>);
                var repositoryInstance = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(TEntity)), _projectContext);

                _repositories.Add(type, repositoryInstance);
            }

            return (IGenericRepository<TEntity>) _repositories[type];
        }
    }
}