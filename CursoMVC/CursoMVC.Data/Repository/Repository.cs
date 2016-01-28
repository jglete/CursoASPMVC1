namespace CursoMVC.Data.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Data.Entity;
    using System.Text;

    public class Repository<T> : CursoMVC.Domain.Contracts.IRepository<T> where T : class
    {
        protected DbContext context;
        private bool disposed = false;

        #region Constructor
        public Repository(DbContext dataContext)
        {
            this.context = dataContext;
            //System.Diagnostics.Debug.WriteLine(this.context.Database.Connection.State.ToString());
        }
        #endregion

        #region Members
        public void Insert(T entity)
        {
            this.context.Set<T>().Add(entity);
        }

        public void Delete(T entity)
        {
            this.context.Set<T>().Remove(entity);
        }

        public IQueryable<T> SearchFor(Expression<Func<T, bool>> predicate)
        {
            return this.context.Set<T>().Where<T>(predicate);
        }

        public IEnumerable<T> GetAll()
        {
            return this.context.Set<T>().ToList<T>();
        }

        public IQueryable<T> GetSet()
        {
            return this.context.Set<T>();
        }

        public T GetById(int id)
        {
            return this.context.Set<T>().Find(id);
        }

        public void Save()
        {
            try
            {
                this.context.SaveChanges();
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                StringBuilder sb = new StringBuilder();

                throw new System.Data.Entity.Validation.DbEntityValidationException(
                    "Entity Validation Failed - errors follow:\n" +
                    sb.ToString(), ex
                ); // Add the original exception as the innerException
            }
        }
        #endregion

        #region "Dispose"
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
