using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoMVC.Service
{
    public interface IAppService: IDisposable
    {
        ICollection<Domain.Invoice> AllInvoices();
        ICollection<Domain.Customer> AllCustomers();
        ICollection<Domain.Product> AllProducts();
        //DTO.Invoice GetNewInvoice();
    }
}
