using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Medica.Models;

namespace Medica.Controllers
{
    public class PregledsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Pregleds
        public ActionResult Index()
        {
            return View(db.Pregleds.ToList());
        }

        // GET: Pregleds/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pregled pregled = db.Pregleds.Find(id);
            if (pregled == null)
            {
                return HttpNotFound();
            }
            return View(pregled);
        }

        // GET: Pregleds/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Pregleds/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PregledID,Datum,VrijemePocetka,VrijemeZavrsetka")] Pregled pregled)
        {
            if (ModelState.IsValid)
            {
                db.Pregleds.Add(pregled);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pregled);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Zakazi(int? id)
        {
            return View("~View/Home/Index.cshtml");
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usluga usluga = db.Uslugas.Find(id);
            if (usluga == null)
            {
                return HttpNotFound();
            }
            if (ModelState.IsValid)
            {
                //pregled.Usluga = usluga;
                //db.Pregleds.Add(pregled);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(usluga);
        }

        // GET: Pregleds/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pregled pregled = db.Pregleds.Find(id);
            if (pregled == null)
            {
                return HttpNotFound();
            }
            return View(pregled);
        }

        // POST: Pregleds/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PregledID,Datum,VrijemePocetka,VrijemeZavrsetka")] Pregled pregled)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pregled).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pregled);
        }

        // GET: Pregleds/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pregled pregled = db.Pregleds.Find(id);
            if (pregled == null)
            {
                return HttpNotFound();
            }
            return View(pregled);
        }

        // POST: Pregleds/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Pregled pregled = db.Pregleds.Find(id);
            db.Pregleds.Remove(pregled);
            db.SaveChanges();
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
