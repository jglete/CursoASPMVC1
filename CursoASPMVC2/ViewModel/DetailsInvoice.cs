using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CursoASPMVC2.ViewModel
{
    public class DetailsInvoice
    {
        public int InvoiceId { get; set; }
        public int CustomerId { get; set; }
        public string Reference { get; set; }
        public System.DateTime Date { get; set; }

        public virtual CursoASPMVC2.Domain.Customer Customer { get; set; }
        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<CursoASPMVC2.Domain.InvoiceLine> InvoiceLines { get; set; }
        public virtual ICollection<CursoASPMVC2.ViewModel.DetailsInvoiceLine> InvoiceLines { get; set; }
        public decimal Total { get; set; }
    }
}