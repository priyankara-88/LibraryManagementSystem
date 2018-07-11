using LibraryManagementSystem.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Data.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        #region Members
        protected readonly LibraryDbContext _dbContext = null;
        #endregion Members

        #region Init
        public Repository(LibraryDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        #endregion Init

        #region Private Methods
        protected void Save() => _dbContext.SaveChanges();
        #endregion Private Methods

        #region Public Methods
        public int Count(Func<T, bool> predcate)
        {
            return _dbContext.Set<T>().Where(predcate).Count();
        }

        public void Create(T entity)
        {
            _dbContext.Add(entity);
            Save();
        }

        public void Delete(T entity)
        {
            _dbContext.Remove(entity);
            Save();
        }

        public IEnumerable<T> Find(Func<T, bool> predicate)
        {
            return _dbContext.Set<T>().Where(predicate);
        }

        public IEnumerable<T> GetAll()
        {
            return _dbContext.Set<T>();
        }

        public T GetById(int id)
        {
            return _dbContext.Set<T>().Find(id);
        }

        public void Update(T entity)
        {
            _dbContext.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            Save();
        } 
        #endregion
    }
}
