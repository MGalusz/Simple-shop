using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Simple_shop.DAL;
using Simple_shop.Models;
using System.Dynamic;

namespace Simple_shop.Controllers
{
    public class HomeController : Controller
    {
      
        private  CourseContext db = new CourseContext();
        public ActionResult Index()
        {
            var listaCatt = db.Categories.ToList();
            return View();
        }
    }
}