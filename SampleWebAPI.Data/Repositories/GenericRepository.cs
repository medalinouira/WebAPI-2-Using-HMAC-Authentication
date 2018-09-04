using System.Linq;
using SampleWebAPI.Domain.IRepositories;

namespace SampleWebAPI.Data
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class, new()
    {
        #region Fields
        #endregion

        #region Constructor
        public GenericRepository()
        {
        
        }
        #endregion

        #region Methods
        //TODO Implement GetAll
        public virtual IQueryable<TEntity> GetAll()
        {
            return null;
        }

        //TODO Implement GetByID
        public virtual TEntity GetByID(object id)
        {
            return new TEntity();
        }

        //TODO Implement Insert
        public virtual void Insert(TEntity entity)
        {
        }

        //TODO Implement DeleteById
        public virtual void DeleteById(object id)
        {
        }

        //TODO Implement Delete
        public virtual void Delete(TEntity entityToDelete)
        {
        }

        //TODO Implement Update
        public virtual void Update(TEntity entityToUpdate)
        {
        }
        #endregion
    }
}