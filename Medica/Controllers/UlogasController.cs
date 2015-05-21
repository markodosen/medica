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
    public class UlogasController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Ulogas
        public ActionResult Index()
        {
            return View(db.Ulogas.ToList());
        }

        // GET: Ulogas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Uloga uloga = db.Ulogas.Find(id);
            if (uloga == null)
            {
                return HttpNotFound();
            }
            return View(uloga);
        }

        // GET: Ulogas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Ulogas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UlogaID,Ime,Opis")] Uloga uloga)
        {
            if (ModelState.IsValid)
            {
                db.Ulogas.Add(uloga);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(uloga);
        }

        // GET: Ulogas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Uloga uloga = db.Ulogas.Find(id);
            if (uloga == null)
            {
                return HttpNotFound();
            }
            return View(uloga);
        }

        // POST: Ulogas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UlogaID,Ime,Opis")] Uloga uloga)
        {
            if (ModelState.IsValid)
            {
                db.Entry(uloga).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(uloga);
        }

        // GET: Ulogas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Uloga uloga = db.Ulogas.Find(id);
            if (uloga == null)
            {
                return HttpNotFound();
            }
            return View(uloga);
        }

        // POST: Ulogas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Uloga uloga = db.Ulogas.Find(id);
            db.Ulogas.Remove(uloga);
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
