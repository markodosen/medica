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
    public class UslugasController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Uslugas
        public ActionResult Index()
        {
            var uslugas = db.Uslugas.Include(u => u.Zaposleni);
            return View(uslugas.ToList());
        }

        // GET: Uslugas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usluga usluga = db.Uslugas.Find(id);
            if (usluga == null)
            {
                return HttpNotFound();
            }
            return View(usluga);
        }

        // GET: Uslugas/Create
        public ActionResult Create()
        {
            ViewBag.ZaposleniID = new SelectList(db.Zaposlenis, "ZaposleniID", "PunoIme");
            return View();
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UslugaID,Ime,Cijena,Trajanje,Opis,ZaposleniID")] Usluga usluga)
        {
            if (ModelState.IsValid)
            {
                db.Uslugas.Add(usluga);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ZaposleniID = new SelectList(db.Zaposlenis, "ZaposleniID", "Ime", usluga.ZaposleniID);
            return View(usluga);
        }

        // GET: Uslugas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usluga usluga = db.Uslugas.Find(id);
            if (usluga == null)
            {
                return HttpNotFound();
            }
            ViewBag.ZaposleniID = new SelectList(db.Zaposlenis, "ZaposleniID", "Ime", usluga.ZaposleniID);
            return View(usluga);
        }


        public ActionResult Zakazi(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usluga usluga = db.Uslugas.Find(id);
            if (usluga == null)
            {
                return HttpNotFound();
            }

            return View("~/Views/Pregleds/Create.cshtml");
        }
       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UslugaID,Ime,Cijena,Trajanje,Opis,ZaposleniID")] Usluga usluga)
        {
            if (ModelState.IsValid)
            {
                db.Entry(usluga).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ZaposleniID = new SelectList(db.Zaposlenis, "ZaposleniID", "Ime", usluga.ZaposleniID);
            return View(usluga);
        }

        // GET: Uslugas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usluga usluga = db.Uslugas.Find(id);
            if (usluga == null)
            {
                return HttpNotFound();
            }
            return View(usluga);
        }

        // POST: Uslugas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Usluga usluga = db.Uslugas.Find(id);
            db.Uslugas.Remove(usluga);
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
