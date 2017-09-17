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
            return DbSet.Find(id);
        }

        public void Add(TEntity entity){
            DbSet.Add(entity);
        }

        public void AddRange(IEnumerable<TEntity> entities){
            foreach (var entity in entities){
                Add(entity);
            }
        }

        public void Delete(TEntity entity){
            DbSet.Remove(entity);
        }

        public void Delete(int id){
            TEntity entity = DbSet.Find(id);
            if (entity != null){
                Delete(entity);
            }
            else{
                throw new Exception("Don't exist");
            }
        }

        public void Update(TEntity entity){
            DbSet.Attach(entity);
            DbContext.Entry(entity).State = EntityState.Modified;
        }

        public void Update(int id){
            TEntity entity = DbSet.Find(id);
            if (entity != null){
                Update(entity);
            }
            else{
                throw new Exception("Don't exist");
            }
        }
    }
}
