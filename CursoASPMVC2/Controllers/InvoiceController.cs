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

        public ActionResult Index()
        {
            return View(this._Service.AllInvoices());
        }

        public ActionResult DetailsInvoice(int? Id)
        {
            if (Id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            CursoASPMVC2.Domain.Invoice invoice = this._Service.AllInvoices().FirstOrDefault(m => m.InvoiceId == Id);
            if (invoice == null)
            {
                return HttpNotFound();
            }
            ViewModel.DetailsInvoice mDetailsInvoice = new ViewModel.DetailsInvoice();
            AutoMapper.Mapper.Map<CursoASPMVC2.Domain.Invoice, CursoASPMVC2.ViewModel.DetailsInvoice>(invoice, mDetailsInvoice);
            return View(mDetailsInvoice);
        }

        public ActionResult CreateInvoice()
        {
            ViewModel.CreateInvoiceComplete mCreateInvoiceComplete = new ViewModel.CreateInvoiceComplete();

            ////Pasar la siguiente lógica al servicio:
            //mCreateInvoiceComplete.Customers = this._Service.AllCustomers().Select(u => new SelectListItem
            //{
            //    Text = u.Name,
            //    Value = u.CustomerId.ToString()
            //}).ToList();
            //mCreateInvoiceComplete.Products = this._Service.AllProducts().Select(u => new SelectListItem
            //{
            //    Text = u.Title,
            //    Value = u.ProductId.ToString()
            //}).ToList();

            Service.DTO.Invoice mInvoice = this._Service.GetNewInvoice();

            AutoMapper.Mapper.Map<Service.DTO.Invoice, CursoASPMVC2.ViewModel.CreateInvoiceComplete>(mInvoice, mCreateInvoiceComplete);

            return View(mCreateInvoiceComplete);
        }

        //public ActionResult EditInvoice(int? Id)
        //{
        //    if (Id == null)
        //    {
        //        return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
        //    }
        //    ViewModel.EditInvoiceComplete mEditInvoiceComplete = new ViewModel.EditInvoiceComplete();
        //    AutoMapper.Mapper.Map<CursoASPMVC2.Domain.Invoice, CursoASPMVC2.ViewModel.EditInvoiceComplete>(this._Service.AllInvoices().FirstOrDefault(m => m.InvoiceId == Id), mEditInvoiceComplete);
        //    mEditInvoiceComplete.Customers = this._Service.AllCustomers().Select(u => new SelectListItem
        //    {
        //        Text = u.Name,
        //        Value = u.CustomerId.ToString()
        //    }).ToList();
        //    mEditInvoiceComplete.Products = this._Service.AllProducts().Select(u => new SelectListItem
        //    {
        //        Text = u.Title,
        //        Value = u.ProductId.ToString()
        //    }).ToList();
        //    return View(mEditInvoiceComplete);
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult EditInvoice(CursoASPMVC2.Domain.Invoice Invoice)
        //{
        //    try
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            CursoASPMVC2.Domain.Invoice mInvoice = this._Service.AllInvoices().FirstOrDefault(m => m.InvoiceId == Invoice.InvoiceId);
        //            //mProduct = Product;
        //           // mProduct.Title = Product.Title;
        //            //mProduct.UnitPrice = Product.UnitPrice;
        //            //this._Service..GetEntities().SaveChanges();
        //            return RedirectToAction("Index");
        //        }
        //    }
        //    catch (System.Data.DataException)
        //    {
        //        ModelState.AddModelError("", "No ha sido posible guardar los datos.");
        //    }
        //    return View(Invoice);
        //}

        protected override void Dispose(bool disposing)
        {
            this._Service.Dispose();
            base.Dispose(disposing);
        }
    }
}