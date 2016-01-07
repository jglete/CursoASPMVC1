using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CursoASPMVC1.Controllers
{
    public class HomeController : Controller
    {
        private CursoASPMVC1.Models.CursoASPMVCEntities Entities;

        public HomeController()
        {
            Entities = new Models.CursoASPMVCEntities();
        }
        public ActionResult Index()
        {
            Models.Company mCompany = Entities.Companies.FirstOrDefault(m => m.CompanyId > 0);
            ViewBag.Company = mCompany != default(Models.Company) ? mCompany.Title : "No hay compañías";
            ViewBag.CompanyId = mCompany != default(Models.Company) ? mCompany.CompanyId : 0;
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
        
        public ActionResult CreateCompany()
        {
            return View(new Models.Company());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateCompany([Bind(Include = "Title, Address, CreationDate")]Models.Company Company)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Entities.Companies.Add(Company);
                    Entities.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (System.Data.DataException )
            {
                ModelState.AddModelError("", "No ha sido posible guardar los datos.");
            }
            return View(Company);
        }

        public ActionResult EditCompany(int? Id)
        {
            if (Id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            return View(Entities.Companies.FirstOrDefault(m => m.CompanyId == Id));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditCompany([Bind(Include = "Title, Address, CreationDate, CompanyId")]Models.Company Company)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Models.Company mCompany = Entities.Companies.FirstOrDefault(m => m.CompanyId == Company.CompanyId);
                    mCompany.Title = Company.Title;
                    mCompany.Address = Company.Address;
                    mCompany.CreationDate = Company.CreationDate;
                    Entities.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (System.Data.DataException)
            {
                ModelState.AddModelError("", "No ha sido posible guardar los datos.");
            }
            return View(Company);
        }

        public ActionResult DeleteCompany(int? Id)
        {
            if (Id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            return View(Entities.Companies.FirstOrDefault(m => m.CompanyId == Id));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteCompany([Bind(Include = "CompanyId")]Models.Company Company)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Models.Company mCompany = Entities.Companies.FirstOrDefault(m => m.CompanyId == Company.CompanyId);
                    Entities.Companies.Remove(mCompany);
                    //Models.Company companyToDelete = new Models.Company() { CompanyId = Company.CompanyId };
                    //Entities.Entry(companyToDelete).State = System.Data.Entity.EntityState.Deleted;

                    Entities.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (System.Data.DataException ex)
            {

                ModelState.AddModelError("", ex.ToString());
            }
            return View(Company);
        }

        protected override void Dispose(bool disposing)
        {
            Entities.Dispose();
            base.Dispose(disposing);
        }
    }
}