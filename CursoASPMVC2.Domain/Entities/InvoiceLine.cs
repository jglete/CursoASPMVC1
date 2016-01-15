namespace CursoASPMVC2.Domain
{
    using System;
    using System.Collections.Generic;

    public partial class InvoiceLine
    {
        public decimal TotalLine 
        { 
            get 
            {
                return UnitPrice * Quantity;
            } 
        }
    }
}