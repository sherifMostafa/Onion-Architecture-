using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using OnionArchitect.Core.Extensions;
using OnionArchitect.Core.Repository.Generic;
using OnionArchitect.Core.Service.Generic;
using OnionArchitect.Core.UnitOfWork;

namespace OnionArchitect.Services.Generic
{
    public class Service<TEntity> : IService<TEntity> where TEntity : class
    {
        protected readonly IRepository<TEntity> _repository;
        protected readonly IUnitOfWork _unitOfWork;

        #region Ctor

        public Service(IUnitOfWork unitOfWork, IRepository<TEntity> repository)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
        }

        #endregion Ctor

        #region IService

        public virtual void Add(TEntity entity)
        {
            _repository.Add(entity);
            _unitOfWork.SaveChanges();
        }

        public virtual void AddRange(IEnumerable<TEntity> entities)
        {
            _repository.AddRange(entities);
            _unitOfWork.SaveChanges();
        }

        public virtual void Edit(TEntity entity)
        {
            _repository.Edit(entity);
            _unitOfWork.SaveChanges();
        }

        public virtual void EditRange(IEnumerable<TEntity> entities)
        {
            entities.ForEach(e => _repository.Edit(e));
            _unitOfWork.SaveChanges();
        }

        public virtual void Remove(TEntity entity)
        {
            _repository.Remove(entity);
            _unitOfWork.SaveChanges();
        }

        public virtual void RemoveRange(IEnumerable<TEntity> entities)
        {
            _repository.RemoveRange(entities);
            _unitOfWork.SaveChanges();
        }

        public virtual TEntity GetById(object id)
        {
            return _repository.GetById(id);
        }

      
        public virtual IEnumerable<TEntity> GetAll()
        {
            return _repository.GetAll();
        }

        public virtual IEnumerable<TEntity> GetAll(params string[] includingTables)
        {
            return _repository.GetAll(includingTables);
        }

        public virtual IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return _repository.Find(predicate);
        }

        public virtual IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate, params string[] includingTables)
        {
            return _repository.Find(predicate, includingTables);
        }

        

       
        public virtual Task AddAsync(TEntity entity)
        {
            _repository.Add(entity);
            return _unitOfWork.SaveChangesAsync();
        }

        public virtual Task AddRangeAsync(IEnumerable<TEntity> entities)
        {
            _repository.AddRange(entities);
            return _unitOfWork.SaveChangesAsync();
        }

        public virtual Task EditAsync(TEntity entity)
        {
            _repository.Edit(entity);
            return _unitOfWork.SaveChangesAsync();
        }

        public virtual Task EditRangeAsync(IEnumerable<TEntity> entities)
        {
            entities.ForEach(e => _repository.Edit(e));
            return _unitOfWork.SaveChangesAsync();
        }

        public virtual Task RemoveAsync(TEntity entity)
        {
            _repository.Remove(entity);
            return _unitOfWork.SaveChangesAsync();
        }

        public virtual Task RemoveRangeAsync(IEnumerable<TEntity> entities)
        {
            _repository.RemoveRange(entities);
            return _unitOfWork.SaveChangesAsync();
        }

        public virtual Task<TEntity> GetByIdAsync(object id)
        {
            return _repository.GetByIdAsync(id);
        }

        public virtual Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return _repository.GetAllAsync();
        }

        public virtual Task<IEnumerable<TEntity>> GetAllAsync(params string[] includingTables)
        {
            return _repository.GetAllAsync(includingTables);
        }

        public virtual Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return _repository.FindAsync(predicate);
        }

        public virtual Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate, params string[] includingTables)
        {
            return _repository.FindAsync(predicate, includingTables);
        }

      
     
        #endregion IService
    }
}
