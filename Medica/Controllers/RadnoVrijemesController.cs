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
    public class RadnoVrijemesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: RadnoVrijemes
        public ActionResult Index()
        {
            if (Session["user"] == null)
            {
                return RedirectToAction("Login", "Login");
            }
            return View(db.RadnoVrijemes.ToList());
        }

        // GET: RadnoVrijemes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RadnoVrijeme radnoVrijeme = db.RadnoVrijemes.Find(id);
            if (radnoVrijeme == null)
            {
                return HttpNotFound();
            }
            return View(radnoVrijeme);
        }

        // GET: RadnoVrijemes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RadnoVrijemes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RadnoVrijemeID,Dan,SatiOd,SatiDo")] RadnoVrijeme radnoVrijeme)
        {
            if (ModelState.IsValid)
            {
                db.RadnoVrijemes.Add(radnoVrijeme);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(radnoVrijeme);
        }

        // GET: RadnoVrijemes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RadnoVrijeme radnoVrijeme = db.RadnoVrijemes.Find(id);
            if (radnoVrijeme == null)
            {
                return HttpNotFound();
            }
            return View(radnoVrijeme);
        }

        // POST: RadnoVrijemes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RadnoVrijemeID,Dan,SatiOd,SatiDo")] RadnoVrijeme radnoVrijeme)
        {
            if (ModelState.IsValid)
            {
                db.Entry(radnoVrijeme).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(radnoVrijeme);
        }

        // GET: RadnoVrijemes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RadnoVrijeme radnoVrijeme = db.RadnoVrijemes.Find(id);
            if (radnoVrijeme == null)
            {
                return HttpNotFound();
            }
            return View(radnoVrijeme);
        }

        // POST: RadnoVrijemes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RadnoVrijeme radnoVrijeme = db.RadnoVrijemes.Find(id);
            db.RadnoVrijemes.Remove(radnoVrijeme);
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
