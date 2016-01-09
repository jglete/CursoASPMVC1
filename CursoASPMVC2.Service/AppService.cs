using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoASPMVC2.Service
{
    public class AppService : IAppService
    {
        private Domain.Contracts.ICompanyRepository _Repository;

        public AppService(Domain.Contracts.ICompanyRepository CompanyRepository)
        {
            this._Repository = CompanyRepository;
        }

        public ICollection<Domain.Invoice> AllInvoices()
        {
            return this._Repository.AllInvoices();
        }
    }
}
