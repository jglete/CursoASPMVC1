using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoASPMVC2.Domain.Contracts
{
    public interface ICompanyUoW : IDisposable
    {
        Domain.Contracts.ICompanyRepository CompanyRepository();
        Domain.Contracts.IRepository<Domain.Customer> CustomerRepository();
        Domain.Contracts.IRepository<Domain.Product> ProductRepository();

        void Save();
    }
}
