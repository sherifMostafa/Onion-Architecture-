using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace OnionArchitect.Core.Service.Generic
{
    public interface IService<TEntity> where TEntity : class
    {

        #region Insert

        void Add(TEntity entity);

        Task AddAsync(TEntity entity);

        void AddRange(IEnumerable<TEntity> entities);

        Task AddRangeAsync(IEnumerable<TEntity> entities);

        #endregion Insert

        #region Update

        void Edit(TEntity entity);

        void EditRange(IEnumerable<TEntity> entities);

        Task EditAsync(TEntity entity);

        Task EditRangeAsync(IEnumerable<TEntity> entities);

        #endregion Update

        #region Delete

        void Remove(TEntity entity);

        Task RemoveAsync(TEntity entity);

        void RemoveRange(IEnumerable<TEntity> entities);

        Task RemoveRangeAsync(IEnumerable<TEntity> entities);

        #endregion Delete

        #region Select

        TEntity GetById(object id);

        Task<TEntity> GetByIdAsync(object id);

        IEnumerable<TEntity> GetAll();

        Task<IEnumerable<TEntity>> GetAllAsync();

        IEnumerable<TEntity> GetAll(params string[] includingTables);

        Task<IEnumerable<TEntity>> GetAllAsync(params string[] includingTables);

        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);

        Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate);

        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate, params string[] includingTables);

        Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate, params string[] includingTables);

        #endregion Select

    }
}
