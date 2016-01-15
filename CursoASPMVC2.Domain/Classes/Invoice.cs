namespace CursoASPMVC2.Domain
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public partial class Invoice
    {
        public decimal Total 
        {
            get
            {
                return InvoiceLines == null ? 0 : InvoiceLines.Sum(x => x.TotalLine);
            }
        }
    }
}