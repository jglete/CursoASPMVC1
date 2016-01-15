using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CursoASPMVC2.ViewModel
{
    public class EditInvoiceComplete
    {
        public EditInvoiceComplete()
        {
            //this.InvoiceLines = new HashSet<CursoASPMVC2.Domain.InvoiceLine>();
        }
        public int InvoiceId { get; set; }
        public int CustomerId { get; set; }
        public string Reference { get; set; }
        public System.DateTime Date { get; set; }

        public virtual CursoASPMVC2.Domain.Customer Customer { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CursoASPMVC2.Domain.InvoiceLine> InvoiceLines { get; set; }

        //Colecciones para listas
        public List<System.Web.Mvc.SelectListItem> Customers { get; set; }
        public List<System.Web.Mvc.SelectListItem> Products { get; set; }

        //Propiedades para la creación de líneas dinámicas
        public int ProductId { get; set; }
        public string Title { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
    }
}