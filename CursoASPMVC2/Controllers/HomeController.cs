using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CursoASPMVC2.Controllers
{
    public class HomeController : Controller
    {
        public CursoASPMVC2.Service.ProductsService Service;
        public HomeController()
        {
            this.Service = new Service.ProductsService();
        }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        #region Productos
        public ActionResult Products()
        {
            return View(this.Service.GetEntities().Products.ToList<CursoASPMVC2.Domain.Product>());
        }

        public ActionResult CreateProduct()
        {
            return View(new CursoASPMVC2.Domain.Product());
        }
        public ActionResult EditProduct(int? Id)
        {
            if (Id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            return View(this.Service.GetEntities().Products.FirstOrDefault(m => m.ProductId == Id));
        }
        public ActionResult DetailsProduct(int? Id)
        {
            if (Id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            return View(this.Service.GetEntities().Products.FirstOrDefault(m => m.ProductId == Id));
        }
        public ActionResult DeleteProduct(int? Id)
        {
            if (Id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            return View(this.Service.GetEntities().Products.FirstOrDefault(m => m.ProductId == Id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateProduct(CursoASPMVC2.Domain.Product Product)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    this.Service.GetEntities().Products.Add(Product);
                    this.Service.GetEntities().SaveChanges();
                    return RedirectToAction("Products");
                }
            }
            catch (System.Data.DataException)
            {
                ModelState.AddModelError("", "No ha sido posible guardar los datos.");
            }
            return View(Product);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditProduct(CursoASPMVC2.Domain.Product Product)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    CursoASPMVC2.Domain.Product mProduct = this.Service.GetEntities().Products.FirstOrDefault(m => m.ProductId == Product.ProductId);
                    //mProduct = Product;
                    mProduct.Title = Product.Title;
                    mProduct.UnitPrice = Product.UnitPrice;
                    this.Service.GetEntities().SaveChanges();
                    return RedirectToAction("Products");
                }
            }
            catch (System.Data.DataException)
            {
                ModelState.AddModelError("", "No ha sido posible guardar los datos.");
            }
            return View(Product);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteProduct(CursoASPMVC2.Domain.Product Product)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    CursoASPMVC2.Domain.Product mProduct = this.Service.GetEntities().Products.FirstOrDefault(m => m.ProductId == Product.ProductId);
                    this.Service.GetEntities().Products.Remove(mProduct);
                    //Models.Company companyToDelete = new Models.Company() { CompanyId = Company.CompanyId };
                    //Entities.Entry(companyToDelete).State = System.Data.Entity.EntityState.Deleted;

                    this.Service.GetEntities().SaveChanges();
                    return RedirectToAction("Products");
                }
            }
            catch (System.Data.DataException ex)
            {

                ModelState.AddModelError("", ex.ToString());
            }
            return View(Product);
        }
        #endregion

        #region Facturas
        public ActionResult Invoices()
        {
            return View(this.Service.GetEntities().Companies.FirstOrDefault().Invoices.ToList());
        }
        public ActionResult CreateInvoice()
        {
            List<SelectListItem> companies = this.Service.GetEntities().Companies.ToList().Select(u => new SelectListItem
                                    {
                                        Text = u.Title,
                                        Value = u.CompanyId.ToString()
                                    }).ToList();
            ViewBag.Companies = companies;

            List<SelectListItem> customers = this.Service.GetEntities().Customers.ToList().Select(u => new SelectListItem
            {
                Text = u.Name,
                Value = u.CustomerId.ToString()
            }).ToList();
            ViewBag.Customers = customers;

            return View(new CursoASPMVC2.Domain.Invoice());
        }
        public ActionResult CreateInvoiceVM()
        {
            ViewModel.CreateInvoice mCreateInvoice = new ViewModel.CreateInvoice();
            mCreateInvoice.Customers = this.Service.GetEntities().Customers.ToList().Select(u => new SelectListItem
            {
                Text = u.Name,
                Value = u.CustomerId.ToString()
            }).ToList();
            return View(mCreateInvoice);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateInvoiceVM(ViewModel.CreateInvoice CreateInvoice)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Domain.Invoice mInvoice = new Domain.Invoice();
                    //mInvoice.Reference = CreateInvoice.Reference;
                    //mInvoice.CustomerId = CreateInvoice.CustomerId;
                    //mInvoice.Date = CreateInvoice.Date;
                    AutoMapper.Mapper.Map(CreateInvoice, mInvoice);

                    this.Service.GetEntities().Companies.FirstOrDefault().Invoices.Add(mInvoice);
                    this.Service.GetEntities().SaveChanges();
                    return RedirectToAction("Invoices");
                }
            }
            catch (System.Data.DataException)
            {
                ModelState.AddModelError("", "No ha sido posible guardar los datos.");
            }

            CreateInvoice.Customers = this.Service.GetEntities().Customers.ToList().Select(u => new SelectListItem
            {
                Text = u.Name,
                Value = u.CustomerId.ToString()
            }).ToList();
            return View(CreateInvoice);
        }

        public ActionResult CreateInvoiceComplete()
        {
            ViewModel.CreateInvoiceComplete mCreateInvoiceComplete = new ViewModel.CreateInvoiceComplete();
            mCreateInvoiceComplete.Customers = this.Service.GetEntities().Customers.ToList().Select(u => new SelectListItem
            {
                Text = u.Name,
                Value = u.CustomerId.ToString()
            }).ToList();
            mCreateInvoiceComplete.Products = this.Service.GetEntities().Products.ToList().Select(u => new SelectListItem
            {
                Text = u.Title,
                Value = u.ProductId.ToString()
            }).ToList();
            return View(mCreateInvoiceComplete);
        }
        [HttpPost]
        public ActionResult CreateInvoiceComplete(ViewModel.CreateInvoiceComplete CreateInvoiceComplete)
        {
            return Json(new { 
                success = true, 
                message = "Order updated successfully" }, 
                JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult AddRowToInvoiceLineTable(int ProductId, string Title, int Quantity, decimal UnitPrice)
        {
            ViewModel._InvoiceLineTableRow _InvoiceLineTableRow = new ViewModel._InvoiceLineTableRow() { 
                Quantity = Quantity,
                UnitPrice = UnitPrice,
                Title = Title,
                Product = this.Service.GetEntities().Products.FirstOrDefault(m => m.ProductId == ProductId)
            };
            return PartialView("_InvoiceLineTableRow", _InvoiceLineTableRow);
        }
        #endregion
    }
}