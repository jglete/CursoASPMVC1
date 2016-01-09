using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoASPMVC2.Service
{
    public interface IAppService
    {
        ICollection<Domain.Invoice> AllInvoices();
    }
}
