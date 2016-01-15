using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoASPMVC2.Service.DTO
{
    public class Invoice
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Invoice()
        {
            this.InvoiceLines = new HashSet<Domain.InvoiceLine>();
        }

        public int CustomerId { get; set; }
        public string Reference { get; set; }
        public System.DateTime Date { get; set; }
        public decimal Total { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Domain.InvoiceLine> InvoiceLines { get; set; }

        //Colecciones para listas
        public ICollection<Domain.Customer> Customers { get; set; }
        public ICollection<Domain.Product> Products { get; set; }
    }
}
