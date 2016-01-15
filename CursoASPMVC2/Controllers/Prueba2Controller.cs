using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CursoASPMVC2.Domain;

namespace CursoASPMVC2.Controllers
{
    public class Prueba2Controller : Controller
    {
        private CursoASPMVCEntities db = new CursoASPMVCEntities();

        // GET: Prueba2
        public async Task<ActionResult> Index()
        {
            var invoices = db.Invoices.Include(i => i.Company).Include(i => i.Customer);
            return View(await invoices.ToListAsync());
        }

        // GET: Prueba2/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Invoice invoice = await db.Invoices.FindAsync(id);
            if (invoice == null)
            {
                return HttpNotFound();
            }
            return View(invoice);
        }

        // GET: Prueba2/Create
        public ActionResult Create()
        {
            ViewBag.CompanyId = new SelectList(db.Companies, "CompanyId", "Title");
            ViewBag.CustomerId = new SelectList(db.Customers, "CustomerId", "Name");
            return View();
        }

        // POST: Prueba2/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "InvoiceId,CompanyId,CustomerId,Reference,Date,IsRegistered,CustomerName,CustomerAddress")] Invoice invoice)
        {
            if (ModelState.IsValid)
            {
                db.Invoices.Add(invoice);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.CompanyId = new SelectList(db.Companies, "CompanyId", "Title", invoice.CompanyId);
            ViewBag.CustomerId = new SelectList(db.Customers, "CustomerId", "Name", invoice.CustomerId);
            return View(invoice);
        }

        // GET: Prueba2/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Invoice invoice = await db.Invoices.FindAsync(id);
            if (invoice == null)
            {
                return HttpNotFound();
            }
            ViewBag.CompanyId = new SelectList(db.Companies, "CompanyId", "Title", invoice.CompanyId);
            ViewBag.CustomerId = new SelectList(db.Customers, "CustomerId", "Name", invoice.CustomerId);
            return View(invoice);
        }

        // POST: Prueba2/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "InvoiceId,CompanyId,CustomerId,Reference,Date,IsRegistered,CustomerName,CustomerAddress")] Invoice invoice)
        {
            if (ModelState.IsValid)
            {
                db.Entry(invoice).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.CompanyId = new SelectList(db.Companies, "CompanyId", "Title", invoice.CompanyId);
            ViewBag.CustomerId = new SelectList(db.Customers, "CustomerId", "Name", invoice.CustomerId);
            return View(invoice);
        }

        // GET: Prueba2/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Invoice invoice = await db.Invoices.FindAsync(id);
            if (invoice == null)
            {
                return HttpNotFound();
            }
            return View(invoice);
        }

        // POST: Prueba2/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Invoice invoice = await db.Invoices.FindAsync(id);
            db.Invoices.Remove(invoice);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
