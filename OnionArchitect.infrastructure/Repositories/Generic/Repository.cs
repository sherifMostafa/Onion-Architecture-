using Microsoft.EntityFrameworkCore;
using OnionArchitect.Core.Repository.Generic;
using OnionArchitect.infrastructure.DbContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OnionArchitect.infrastructure.Repositories.Generic
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        #region Fields

        private readonly IDatabaseContext _databaseContext;
        private readonly DbSet<TEntity> _entitiesSet;

        #endregion Fields

        #region ctor

        public Repository(IDatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
            _entitiesSet = _databaseContext.Set<TEntity>();
        }

        #endregion ctor

        #region Repository

        #region add 
        public void Add(TEntity entity)
        {
            _entitiesSet.Add(entity);
        }

        public void AddRange(IEnumerable<TEntity> entities)
        {
            _entitiesSet.AddRange(entities);
        }
        #endregion

        #region Edit

        public void Edit(TEntity entity)
        {
            _entitiesSet.Update(entity);
        }

        #endregion Edit

        #region select

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return _entitiesSet.Where(predicate).AsNoTracking().AsEnumerable<TEntity>();
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate, params string[] includingTables)
        {
            IQueryable<TEntity> entitiesList = _entitiesSet.AsNoTracking().AsQueryable();

            if (includingTables != null)
                for (int i = 0; i < includingTables.Length; i++)
                    entitiesList = entitiesList.Include(includingTables[i]);

            return entitiesList
                .Where(predicate)
                .AsEnumerable<TEntity>();
        }

        public Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return
                Task.Run(() =>
                        _entitiesSet
                            .Where(predicate)
                            .AsNoTracking()
                            .AsEnumerable<TEntity>()
                    );
        }

        public Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate, params string[] includingTables)
        {
            return
                Task.Run(() =>
                {
                    IQueryable<TEntity> entitiesList = _entitiesSet.AsQueryable();

                    if (includingTables != null)
                        for (int i = 0; i < includingTables.Length; i++)
                            entitiesList = entitiesList.Include(includingTables[i]);

                    return entitiesList
                            .AsNoTracking()
                            .Where(predicate)
                            .AsEnumerable<TEntity>();
                });
        }

       
        public IEnumerable<TEntity> GetAll()
        {
            return _entitiesSet.AsEnumerable<TEntity>();
        }

        public IEnumerable<TEntity> GetAll(params string[] includingTables)
        {
            IQueryable<TEntity> entitiesList = _entitiesSet.AsQueryable();

            if (includingTables != null)
                for (int i = 0; i < includingTables.Length; i++)
                    entitiesList = entitiesList.Include(includingTables[i]);

            return entitiesList.AsEnumerable<TEntity>();
        }

        public Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return Task.Run(() => _entitiesSet.AsEnumerable<TEntity>());
        }

        public Task<IEnumerable<TEntity>> GetAllAsync(params string[] includingTables)
        {
            return Task.Run(() =>
            {
                IQueryable<TEntity> entitiesList = _entitiesSet.AsQueryable();

                if (includingTables != null)
                    for (int i = 0; i < includingTables.Length; i++)
                        entitiesList = entitiesList.Include(includingTables[i]);

                return entitiesList.AsEnumerable<TEntity>();
            });
        }

        public TEntity GetById(object id)
        {
            return _entitiesSet.Find(id);
        }

        public Task<TEntity> GetByIdAsync(object id)
        {
            return _entitiesSet.FindAsync(id).AsTask();
        }

        #endregion select

        #region Remove

        public void Remove(TEntity entity)
        {
            _entitiesSet.Remove(entity);
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            _entitiesSet.RemoveRange(entities);
        }

        #endregion Remove

        #endregion
    }
}
