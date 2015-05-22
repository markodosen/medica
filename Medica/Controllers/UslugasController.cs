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
            if (Session["user"] == null)
            {
                return RedirectToAction("Login", "Login");
            }
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
                usluga.Status = 1;
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


        Usluga izabranaUsluga = new Usluga();


        public ActionResult Zakazi(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            izabranaUsluga = db.Uslugas.Find(id);
            if (izabranaUsluga == null)
            {
                return HttpNotFound();
            }
            return View();
        }

        [HttpPost]
        public ActionResult Zakazi(DateTime datum, double vrijeme)
        {
            if (!Session["tip"].ToString().Equals("korisnik"))
            {
                return Content("Samo ako ste ulogovani kao korisnik mozete da zakazete pregled");
            }
            
            Random r = new Random();
            Korisnik logedUser = Session["user"] as Korisnik;
            Korisnik korisnik = db.Korisniks.Find(logedUser.KorisnikID);
            String url = Request.Url.AbsoluteUri;
            String uslugaID = url.Substring(url.LastIndexOf("/")+1);
            izabranaUsluga = db.Uslugas.Find(int.Parse(uslugaID));
            int id = r.Next();
            if (db.Pregleds.Find(id) == null)
            {
                Pregled pregled = new Pregled();
                pregled.PregledID = id;
                pregled.Korisnik = korisnik;
                pregled.Usluga = izabranaUsluga;
                pregled.Datum = datum;
                pregled.VrijemePocetka = vrijeme;
                pregled.VrijemeZavrsetka = 0;
                pregled.Status = 0;
                db.Pregleds.Add(pregled);
                db.SaveChanges();
                return View("~/Views/Uslugas/Potvrdi.cshtml");
            }
            return View();
        }
       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UslugaID,Ime,Cijena,Trajanje,Opis,ZaposleniID")] Usluga usluga)
        {
            if (ModelState.IsValid)
            {
                db.Entry(usluga).State = EntityState.Modified;
                db.Entry(usluga).Property(u => u.Status).IsModified = false;
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
            usluga.Zaposleni = null;
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

        public ActionResult Status(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usluga korisnik = db.Uslugas.Find(id);
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
