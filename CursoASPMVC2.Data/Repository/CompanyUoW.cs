using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace CursoASPMVC2.Data.Repository
{
    public class CompanyUoW : Domain.Contracts.ICompanyUoW
    {
        protected DbContext context;
        private bool disposed = false;
        private Domain.Contracts.ICompanyRepository _CompanyRepository;
        private Domain.Contracts.IRepository<Domain.Customer> _CustomerRepository;
        private Domain.Contracts.IRepository<Domain.Product> _ProductRepository;

        #region Constructor
        public CompanyUoW(DbContext dataContext)
        {
            this.context = dataContext;
        }
        public CompanyUoW(DbContext dataContext,
            Domain.Contracts.ICompanyRepository pCompanyRepository,
            Domain.Contracts.IRepository<Domain.Customer> pCustomerRepository,
            Domain.Contracts.IRepository<Domain.Product> pProductRepository)
            : this(dataContext)
        {
            this._CompanyRepository = pCompanyRepository;
            this._CustomerRepository = pCustomerRepository;
            this._ProductRepository = pProductRepository;
        }
        #endregion

        #region repositorios
        public Domain.Contracts.ICompanyRepository CompanyRepository()
        {
            return this._CompanyRepository;
        }
        public Domain.Contracts.IRepository<Domain.Customer> CustomerRepository()
        {
            return this._CustomerRepository;
        }
        public Domain.Contracts.IRepository<Domain.Product> ProductRepository()
        {
            return this._ProductRepository;
        }
        #endregion

        #region métodos globales
        public void Save()
        {
            this.context.SaveChanges();
            //try
            //{
            //    this.context.SaveChanges();
            //}
            //catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            //{
            //    StringBuilder sb = new StringBuilder();
            //    ICollection<Framework.Validation.IValidationError> m_ValidationErrors = new List<Framework.Validation.IValidationError>();

            //    foreach (var failure in ex.EntityValidationErrors)
            //    {
            //        sb.AppendFormat("{0} failed validation\n", failure.Entry.Entity.GetType());
            //        foreach (var error in failure.ValidationErrors)
            //        {
            //            sb.AppendFormat("- {0} : {1}", error.PropertyName, error.ErrorMessage);
            //            sb.AppendLine();

            //            m_ValidationErrors.Add(new Framework.Validation.ValidationError() { PropertyName = error.PropertyName, ErrorMessage = error.ErrorMessage });
            //        }
            //    }

            //    throw new Framework.Validation.ValidationException(
            //        "Entity Validation Failed - errors follow:\n" + sb.ToString(),
            //        ex,
            //        m_ValidationErrors
            //    );
            //}
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
