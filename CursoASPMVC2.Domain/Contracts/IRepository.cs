namespace CursoASPMVC2.Domain.Contracts
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Text;
    using System.Threading.Tasks;

    public interface IRepository<T> : IDisposable
    {
        #region Members
        void Insert(T entity);
        void Delete(T entity);
        IQueryable<T> SearchFor(Expression<Func<T, bool>> predicate);
        IEnumerable<T> GetAll();
        IQueryable<T> GetSet();
        T GetById(int id);
        void Save();
        #endregion
    }
}