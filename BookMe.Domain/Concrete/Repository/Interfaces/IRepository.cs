using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BookMe.Domain.Concrete.Repository.Interfaces {
    public interface IRepository<TEntity> where TEntity : class{
        IQueryable<TEntity> GetAll();
        IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
        TEntity Get(int id);
        void Add(TEntity entity);
        void AddRange(IEnumerable<TEntity> entities);
        void Delete(TEntity entity);
        void Delete(int id);
        void Update(TEntity entity);
        void Update(int id);
    }
}
