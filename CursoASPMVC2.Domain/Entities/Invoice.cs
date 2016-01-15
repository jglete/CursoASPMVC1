namespace CursoASPMVC2.Domain
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public partial class Invoice
    {
        public void CreateNewInvoice()
        {
            this.Reference = System.DateTime.Now.Ticks.ToString();
            this.Date = System.DateTime.Now;
        }
        public decimal Total 
        {
            get
            {
                return InvoiceLines == null ? 0 : InvoiceLines.Sum(x => x.TotalLine);
            }
        }
    }
}