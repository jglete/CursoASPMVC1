namespace CursoMVC.Domain.Contracts
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface ICompanyRepository : IRepository<Company>
    {
        void AddInvoice(Invoice Invoice);
        ICollection<Domain.Invoice> AllInvoices();
        ICollection<Domain.Customer> AllCustomers();
        ICollection<Domain.Product> AllProducts();
    }
}