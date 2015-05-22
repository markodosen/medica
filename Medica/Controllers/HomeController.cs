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
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index()
        {
            if (Session["user"] == null)
            {
                return RedirectToAction("Login", "Login");
            }
            var zaposlenis = db.Zaposlenis.Include(z => z.Uloga);
            return View(zaposlenis.ToList());
        }

        public ActionResult About()
        {
            
            return View();
        }

        public ActionResult Contact()
        {
           
            return View();
        }

        public ActionResult Help()
        {
           
            return View();
        }
    }
}