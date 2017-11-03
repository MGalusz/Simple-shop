using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Simple_shop.Controllers
{
    public class KursyController : Controller
    {
        // GET: Kursy
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Lista(string nazwaKategori)
        {
            return View();
        }
        public ActionResult Sczegoly(string id)
        {
            return View();
        }
    }
}