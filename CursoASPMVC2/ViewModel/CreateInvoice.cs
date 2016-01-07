using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CursoASPMVC2.ViewModel
{
    public class CreateInvoice
    {
        //public int InvoiceId { get; set; }
        //public int CompanyId { get; set; }
        public int CustomerId { get; set; }
        public string Reference { get; set; }
        public System.DateTime Date { get; set; }
        //public bool IsRegistered { get; set; }
        //public string CustomerName { get; set; }
        //public string CustomerAddress { get; set; }

        //public virtual Company Company { get; set; }
        //public virtual CursoASPMVC2.Domain.Customer Customer { get; set; }
        
        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<CursoASPMVC2.Domain.InvoiceLine> InvoiceLines { get; set; }

        //Colecciones para listas
        public List<System.Web.Mvc.SelectListItem> Customers { get; set; }
    }
}