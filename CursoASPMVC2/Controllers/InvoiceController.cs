using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CursoASPMVC2.Controllers
{
    public class InvoiceController : Controller
    {
        private CursoASPMVC2.Service.IAppService _Service;
        public InvoiceController(CursoASPMVC2.Service.IAppService Service)
        {
            this._Service = Service;
        }

        // GET: Invoice
        public ActionResult Index()
        {
            return View(this._Service.AllInvoices());
        }
    }
}