using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using BookMe.Domain.Concrete.Repository.Interfaces;

namespace BookMe.Domain.Concrete.Repository {
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class{
        protected DbContext DbContext { get; set; }
        protected DbSet<TEntity> DbSet { get; set; }

        public Repository(DbContext dbContext){
            DbContext = dbContext;
            DbSet = DbContext.Set<TEntity>();
        }
        public IQueryable<TEntity> GetAll(){
            return DbSet;
        }

        public IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> predicate){
            return DbSet.Where(predicate);
        }

        public TEntity Get(int id){
            throw new NotImplementedException();
        }

        public void Add(TEntity entity){
            throw new NotImplementedException();
        }

        public void AddRange(IEnumerable<TEntity> entities){
            throw new NotImplementedException();
        }

        public void Delete(TEntity entity){
            throw new NotImplementedException();
        }

        public void Delete(int id){
            throw new NotImplementedException();
        }

        public void Update(TEntity entity){
            throw new NotImplementedException();
        }

        public void Update(int id){
            throw new NotImplementedException();
        }
    }
}
