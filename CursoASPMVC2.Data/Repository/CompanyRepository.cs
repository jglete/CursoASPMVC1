namespace CursoASPMVC2.Data.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Data.Entity; //Importante incluir esta referencia, para que nos reconozca el DbContext

    public class CompanyRepository : Repository<CursoASPMVC2.Domain.Company>, Domain.Contracts.ICompanyRepository
    {
        //private DbContext context;

        public CompanyRepository(DbContext dataContext)
            : base(dataContext)
        {
            this.context = dataContext;
        }
        public void AddInvoice(CursoASPMVC2.Domain.Invoice Invoice)
        { 
        }
        public ICollection<Domain.Invoice> AllInvoices()
        {
            //return this.GetAll().FirstOrDefault().Invoices; //Hacemos uso del repositorio con tipo Company.
            return this.context.Set<Domain.Company>().FirstOrDefault().Invoices; //Recogemos directamente del repositorio genérico.
        }
        public ICollection<Domain.Customer> AllCustomers()
        {
            //return this.GetAll().FirstOrDefault().Invoices; //Hacemos uso del repositorio con tipo Company.
            return this.context.Set<Domain.Customer>().ToList(); //Recogemos directamente del repositorio genérico.
        }
        public ICollection<Domain.Product> AllProducts()
        {
            //return this.GetAll().FirstOrDefault().Invoices; //Hacemos uso del repositorio con tipo Company.
            return this.context.Set<Domain.Product>().ToList(); //Recogemos directamente del repositorio genérico.
        }
    }
}
