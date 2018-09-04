using System.Linq;

namespace SampleWebAPI.Domain.IRepositories
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        IQueryable<TEntity> GetAll();
        TEntity GetByID(object id);
        void Insert(TEntity entity);
        void DeleteById(object id);
        void Delete(TEntity entityToDelete);
        void Update(TEntity entityToUpdate);
    }
}
