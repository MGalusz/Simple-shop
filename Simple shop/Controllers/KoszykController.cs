using System;
using System.Collections.Generic;
using System.EnterpriseServices;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Simple_shop.App_Start;
using Simple_shop.DAL;
using Simple_shop.Infrastructure;
using Simple_shop.Models;
using Simple_shop.ViewModels;

namespace Simple_shop.Controllers
{
    public class KoszykController : Controller
    {

        private KoszykMenager koszykMenager;

        private ISessionMenager sessionMenager { get; set; }
        private KursyContext db;


        public KoszykController()
        {
            db = new KursyContext();
            sessionMenager = new SessionMenager();
            koszykMenager = new KoszykMenager(sessionMenager, db);
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

        public async Task<ActionResult> Zaplac()
        {
            if (Request.IsAuthenticated)
            {
                var user = await UserManager.FindByIdAsync(User.Identity.GetUserId());
                var zamownienie = new Zamowienie
                {
                    Imie = user.DaneUzytkownika.Imie,
                    Nazwisko = user.DaneUzytkownika.Nazwisko,
                    Adres = user.DaneUzytkownika.Adres,
                    Miasto = user.DaneUzytkownika.Miasto,
                    KodPocztowy = user.DaneUzytkownika.KodPocztowy,
                    Email = user.DaneUzytkownika.Email,
                    Telefon = user.DaneUzytkownika.Telefon
                };
                return View(zamownienie);
            }
            else
            {
                return RedirectToAction("Login", "Account", new { returnUrl = Url.Action("Zaplac", "Koszyk") });
            }

        }

        private ApplicationUserManager _userManager;
        public ApplicationUserManager UserManager
        {
            get { return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>(); }
            private set { _userManager = value; }
        }
        [HttpPost]
        public async Task<ActionResult> Zaplac(Zamowienie zamowienieSzczegoly)
        {
            if (ModelState.IsValid)
            {
                // pobieramy id uzytkownika aktualnie zalogowanego
                var userId = User.Identity.GetUserId();

                // utworzenie obiektu zamowienia na podstawie tego co mamy w koszyku
                var newOrder = koszykMenager.UtworzZamowienie(zamowienieSzczegoly, userId);

                // szczegóły użytkownika - aktualizacja danych 
                var user = await UserManager.FindByIdAsync(userId);
                TryUpdateModel(user.DaneUzytkownika);
                await UserManager.UpdateAsync(user);

                // opróżnimy nasz koszyk zakupów
                koszykMenager.PustyKoszyk();

                //  maileService.WyslaniePotwierdzenieZamowieniaEmail(newOrder);

                return RedirectToAction("PotwierdzenieZamowienia");
            }
            else
            {
                return View(zamowienieSzczegoly);
            }
        }

        public ActionResult PotwierdzenieZamowienia()
        {
            //var name = User.Identity.Name;
            //logger.Info("Strona koszyk | potwierdzenie | " + name);
            return View();
        }


    }
}