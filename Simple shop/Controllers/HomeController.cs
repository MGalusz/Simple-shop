using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Simple_shop.DAL;
using Simple_shop.Models;
using System.Dynamic;
using Simple_shop.ViewModels;

namespace Simple_shop.Controllers
{
    public class HomeController : Controller
    {
      
        private  CourseContext db = new CourseContext();
        public ActionResult Index()
        {
            var kategoire = db.Categories.ToList();

            var nowosci = db.Courses.Where(x => !x.Hidden).OrderByDescending(x => x.AddDate).Take(3).ToList();

            var bestsellery = db.Courses.Where(x => !x.Hidden && x.Bestseller).OrderBy(x => Guid.NewGuid()).Take(3)
                .ToList();

            var vm = new HomeVM()
            {
                kategorie = kategoire,
                Nowosci = nowosci,
                Bestsellery = bestsellery,

            };
            return View( vm);
        }

        public ActionResult StronyStatyczne(string nazwa)
        {
            return View(nazwa);
        }
    }
}