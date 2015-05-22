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
    public class ZaposlenisController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Zaposlenis
        public ActionResult Index()
        {
            if (Session["user"] == null)
            {
                return RedirectToAction("Login", "Login");
            }
            var zaposlenis = db.Zaposlenis.Include(z => z.Uloga);
            return View(zaposlenis.ToList());
        }

        // GET: Zaposlenis/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Zaposleni zaposleni = db.Zaposlenis.Find(id);
            if (zaposleni == null)
            {
                return HttpNotFound();
            }
            return View(zaposleni);
        }

        // GET: Zaposlenis/Create
        public ActionResult Create()
        {
            ViewBag.UlogaID = new SelectList(db.Ulogas, "UlogaID", "Ime");
            return View();
        }

        // POST: Zaposlenis/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ZaposleniID,Ime,Prezime,Mail,Sifra,Opis,UlogaID")] Zaposleni zaposleni)
        {
            if (ModelState.IsValid)
            {
                zaposleni.Status = 1;
                db.Zaposlenis.Add(zaposleni);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UlogaID = new SelectList(db.Ulogas, "UlogaID", "Ime", zaposleni.UlogaID);
            return View(zaposleni);
        }

        // GET: Zaposlenis/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Zaposleni zaposleni = db.Zaposlenis.Find(id);
            if (zaposleni == null)
            {
                return HttpNotFound();
            }
            ViewBag.UlogaID = new SelectList(db.Ulogas, "UlogaID", "Ime", zaposleni.UlogaID);
            return View(zaposleni);
        }

        // POST: Zaposlenis/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ZaposleniID,Ime,Prezime,Mail,Sifra,Status,Opis,UlogaID")] Zaposleni zaposleni)
        {
            if (ModelState.IsValid)
            {
                db.Entry(zaposleni).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UlogaID = new SelectList(db.Ulogas, "UlogaID", "Ime", zaposleni.UlogaID);
            return View(zaposleni);
        }

        // GET: Zaposlenis/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Zaposleni zaposleni = db.Zaposlenis.Find(id);
            if (zaposleni == null)
            {
                return HttpNotFound();
            }
            return View(zaposleni);
        }

        // POST: Zaposlenis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Zaposleni zaposleni = db.Zaposlenis.Find(id);
            db.Zaposlenis.Remove(zaposleni);
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

        public ActionResult Status(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Zaposleni korisnik = db.Zaposlenis.Find(id);
            if (korisnik == null)
            {
                return HttpNotFound();
            }
            if (korisnik.Status == 1)
            {
                korisnik.Status = 0;
            }
            else
            {
                korisnik.Status = 1;
            }
            db.Entry(korisnik).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
