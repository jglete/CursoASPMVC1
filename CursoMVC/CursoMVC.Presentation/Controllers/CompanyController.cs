using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CursoMVC.Presentation.Controllers
{
    public class CompanyController : Controller
    {
        CursoMVC.Service.IAppService _AppService;

        public CompanyController(CursoMVC.Service.IAppService AppService)
        {
            this._AppService = AppService;
        }

        public ActionResult Index()
        {
            ViewBag.Invoices = this._AppService.AllInvoices();

            return View();
        }
    }
}