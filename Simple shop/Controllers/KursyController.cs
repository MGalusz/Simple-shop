using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Simple_shop.DAL;

namespace Simple_shop.Controllers
{
    public class KursyController : Controller
    {
        private CourseContext db = new CourseContext();
        // GET: Kursy
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Lista(string nazwaKategori)
        {

            var kursy = db.Courses.ToList();
          //  var kategoria = db.Categories.Include("Courses").Where(k => k.nameCategory.ToUpper() == nazwaKategori.ToUpper()).Single();
            //var kursy = kategoria.Coursy.ToList();
            return View(kursy);
        }
        public ActionResult Sczegoly(string id)
        {
            return View();
        }

        [ChildActionOnly]
        public ActionResult KategorieMenu()
        {
            var kategorie = db.Categories.ToList();

            return PartialView("_KategorieMenu", kategorie);
        }
    }
}