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
        private Domain.Contracts.ICompanyUoW _UoW;

        public AppService(Domain.Contracts.ICompanyRepository CompanyRepository, Domain.Contracts.ICompanyUoW UoW)
        {
            this._Repository = CompanyRepository;
            this._UoW = UoW;
        }

        public ICollection<Domain.Invoice> AllInvoices()
        {
            //return this._Repository.AllInvoices();
            return this._UoW.CompanyRepository().AllInvoices();
        }
        public ICollection<Domain.Customer> AllCustomers()
        {
            return this._Repository.AllCustomers(); //Customers no está relacionado con Company. Por lo tanto este servicio deberia utilizar un UoW
        }
        public ICollection<Domain.Product> AllProducts()
        {
            return this._Repository.AllProducts();
        }
        public DTO.Invoice GetNewInvoice()
        {
            DTO.Invoice mInvoice = new DTO.Invoice();
            mInvoice.Reference = System.DateTime.Now.Ticks.ToString();
            mInvoice.Customers = this._Repository.AllCustomers();
            mInvoice.Products = this._Repository.AllProducts();
            return mInvoice;
        }

        public void Dispose()
        {
            this._Repository.Dispose();
        }
    }
}
