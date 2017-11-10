using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Simple_shop.DAL;
using Simple_shop.Models;
using System.Dynamic;
using Simple_shop.Infrastructure;
using Simple_shop.ViewModels;

namespace Simple_shop.Controllers
{
    public class HomeController : Controller
    {
      
        private  KursyContext db = new KursyContext();
        public ActionResult Index()
        {

            ICacheProvider cache = new DefaultCachePrrovider();

            List<Kategoria> kategoire;

            if (cache.IsSet(Consts.KategorieCacheKey))
            {
                kategoire = cache.Get(Consts.KategorieCacheKey) as List<Kategoria>;
            }
            else
            {
                kategoire = db.Kategorie.ToList();
                cache.Set(Consts.KategorieCacheKey, kategoire, 60);
            }

            
            List<Kurs> nowosci;

            if (cache.IsSet(Consts.NowosciCacheKey))
            {
                nowosci = cache.Get(Consts.NowosciCacheKey) as List<Kurs>;
            }
            else
            {  
             nowosci = db.Kursy.Where(x => !x.Ukryty).OrderByDescending(x => x.DataDodania).Take(3).ToList();
                cache.Set(Consts.NowosciCacheKey, nowosci , 60);
            }
            
            
            List<Kurs> bestsellery;

            if (cache.IsSet(Consts.BestselleryCacheKey))
            {
                bestsellery = cache.Get(Consts.BestselleryCacheKey) as List<Kurs>;
            }
            else
            {
                bestsellery = db.Kursy.Where(x => !x.Ukryty && x.Bestseller).OrderBy(x => Guid.NewGuid()).Take(3).ToList();
                cache.Set(Consts.BestselleryCacheKey, nowosci, 60);
            }
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