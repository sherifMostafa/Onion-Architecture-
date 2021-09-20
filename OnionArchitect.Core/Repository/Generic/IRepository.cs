using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OnionArchitect.Core.Repository.Generic
{
    public interface IRepository<TEntity> where TEntity : class
    {
        #region Insert

        void Add(TEntity entity);

        void AddRange(IEnumerable<TEntity> entities);

        #endregion Insert

        #region Update

        void Edit(TEntity entity);

        #endregion Update

        #region Delete

        void Remove(TEntity entity);

        void RemoveRange(IEnumerable<TEntity> entities);

        #endregion Delete

        #region Select

        TEntity GetById(object id);

        IEnumerable<TEntity> GetAll();

        IEnumerable<TEntity> GetAll(params string[] includingTables);

        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);

        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate, params string[] includingTables);

        #endregion Select

        #region Select Async

        Task<TEntity> GetByIdAsync(object id);

        Task<IEnumerable<TEntity>> GetAllAsync();

        Task<IEnumerable<TEntity>> GetAllAsync(params string[] includingTables);

        Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate);

        Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate, params string[] includingTables);


        #endregion Select Async
    }
}
