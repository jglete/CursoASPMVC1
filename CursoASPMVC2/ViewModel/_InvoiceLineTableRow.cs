using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CursoASPMVC2.ViewModel
{
    public class _InvoiceLineTableRow
    {
        //public int ProductId { get; set; }
        public string Title { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }

        public virtual CursoASPMVC2.Domain.Product Product { get; set; }
    }
}