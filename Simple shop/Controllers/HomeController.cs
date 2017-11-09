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
      
        private  KursyContext db = new KursyContext();
        public ActionResult Index()
        {
            var kategoire = db.Kategorie.ToList();

            var nowosci = db.Kursy.Where(x => !x.Ukryty).OrderByDescending(x => x.DataDodania).Take(3).ToList();

            var bestsellery = db.Kursy.Where(x => !x.Ukryty && x.Bestseller).OrderBy(x => Guid.NewGuid()).Take(3)
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