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
        private Domain.Contracts.IInvoiceService _InvoiceService;

        public AppService(Domain.Contracts.ICompanyRepository CompanyRepository, 
            Domain.Contracts.ICompanyUoW UoW,
            Domain.Contracts.IInvoiceService InvoiceService)
        {
            this._Repository = CompanyRepository;
            this._UoW = UoW;
            this._InvoiceService = InvoiceService;
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
            //Domain.Services.InvoiceService mDomainService = new Domain.Services.InvoiceService();
            //Domain.Invoice mInvoice = mDomainService.GetNewInvoice();
            
            Domain.Invoice mInvoice = this._InvoiceService.GetNewInvoice();
            DTO.Invoice mInvoiceDTO = new DTO.Invoice();

            AutoMapper.Mapper.Map<CursoASPMVC2.Domain.Invoice, CursoASPMVC2.Service.DTO.Invoice>(mInvoice, mInvoiceDTO);

            mInvoiceDTO.Customers = this._Repository.AllCustomers();
            mInvoiceDTO.Products = this._Repository.AllProducts();

            return mInvoiceDTO;
        }

        public void Dispose()
        {
            this._Repository.Dispose();
        }
    }
}
