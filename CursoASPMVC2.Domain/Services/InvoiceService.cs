using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoASPMVC2.Domain.Services
{
    public class InvoiceService : Contracts.IInvoiceService
    {
        public InvoiceService()
        { 
        }

        public Domain.Invoice GetNewInvoice()
        {
            Invoice invoice = new Invoice();
            invoice.CreateNewInvoice();
            //invoice.Reference = System.DateTime.Now.Ticks.ToString();
            //invoice.Date = System.DateTime.Now;

            return invoice;
        }
    }
}
