using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Simple_shop.DAL;
using Simple_shop.Infrastructure;
using Simple_shop.ViewModels;

namespace Simple_shop.Controllers
{
    public class KoszykController : Controller
    {

        private KoszykMenager koszykMenager;

        private ISessionMenager sessionMenager { get; set; }
        private KursyContext db ;


        public KoszykController()
        {
            db =  new KursyContext();
            sessionMenager =  new SessionMenager();
            koszykMenager = new KoszykMenager(sessionMenager,db);
        }
        // GET: Koszyk
        public ActionResult Index()
        {
            var pozycjeKoszyka = koszykMenager.PobierzKoszyk();
            var cenaCalkowita = koszykMenager.PobierzWarośćKoszyka();
            KoszykVM koszykVM = new KoszykVM()
            {
                PozycjeKoszyka = pozycjeKoszyka,
                CenaCalkowita = cenaCalkowita
            };
            return View(koszykVM);
        }

        public ActionResult DodajDoKoszyka(int id)
        {

            koszykMenager.DodajDoKoszyka(id);

            return RedirectToAction("Index");
        }

        public int PobierzIloscElemtowKoszyka()
        {
            return koszykMenager.PobierzIlośćPozycjiKozyka();

        }

        public ActionResult UsunZKoszyka(int kursId)
        {
            int iloscPozycji = koszykMenager.UsuńZKoszyka(kursId);
            int iloscPozycjiKoszyka = koszykMenager.PobierzIlośćPozycjiKozyka();
            decimal wartoscKoszyka = koszykMenager.PobierzWarośćKoszyka();

            var wynik = new KoszykUsuwanieVM
            {
                IdPozycjiUsuwanej = kursId,
                IloscPozycjiUsuwanej = iloscPozycji,
                KoszykCenaCalkowita = wartoscKoszyka,
                KoszykIloscPozycji = iloscPozycjiKoszyka,

            };

            return Json(wynik);
        }
    }
}