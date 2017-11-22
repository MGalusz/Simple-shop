using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Simple_shop.DAL;
using Simple_shop.Models;

namespace Simple_shop.Infrastructure
{
    public class KoszykMenager
    {
        private KursyContext db;
        private ISessionMenager session;

        public KoszykMenager(ISessionMenager session, KursyContext db)
        {
            this.session = session;
            this.db = db;
        }

        public List<PozycjaKoszyka> PobierzKoszyk()
        {
            List<PozycjaKoszyka> koszyk;

            if (session.Get<List<PozycjaKoszyka>>(Consts.KoszykSessionKey) == null)
            {
                koszyk = new List<PozycjaKoszyka>();
            }
            else
            {
                koszyk = session.Get<List<PozycjaKoszyka>>(Consts.KoszykSessionKey) as List<PozycjaKoszyka>;
            }

            return koszyk;
        }

        public void DodajDoKoszyka(int kursId)
        {
            var koszyk = PobierzKoszyk();

            var PozycjaKoszyka = koszyk.Find(k => k.Kurs.KursId == kursId);

            if (PozycjaKoszyka != null)
                PozycjaKoszyka.Ilosc++;
            else
            {
                var KursDoDowania = db.Kursy.Where(k => k.KursId == kursId).SingleOrDefault();

                if (KursDoDowania != null)
                {
                    var nowaPozycjaKoszyka = new PozycjaKoszyka()
                    {
                        Kurs = KursDoDowania,
                        Ilosc = 1,
                        Wartosc = KursDoDowania.CenaKursu

                    };
                    koszyk.Add(nowaPozycjaKoszyka);
                }
            }
            session.Set(Consts.KoszykSessionKey, koszyk);

        }

        public int UsuńZKoszyka(int kursId)
        {
            var koszyk = PobierzKoszyk();
            var pozycjaKoszyka = koszyk.Find(k => k.Kurs.KursId == kursId);

            if (pozycjaKoszyka != null)
            {
                if (pozycjaKoszyka.Ilosc > 1)
                {
                    pozycjaKoszyka.Ilosc--;
                    return pozycjaKoszyka.Ilosc;

                }
                else
                {
                    koszyk.Remove(pozycjaKoszyka);
                }
            }
            return 0;
        }

        public decimal PobierzWarośćKoszyka()
        {
            var koszyk = PobierzKoszyk();
            return koszyk.Sum(k => (k.Ilosc * k.Kurs.CenaKursu));
        }

        public int PobierzIlośćPozycjiKozyka()
        {
            var koszyk = PobierzKoszyk();
            int ilosc = koszyk.Sum(k => k.Ilosc);
            return ilosc;
        }

        public Zamowienie UtworzZamowienie(Zamowienie noweZamowienie, string userId)
        {
            var koszyk = PobierzKoszyk();
            noweZamowienie.DataDodania = DateTime.Now;
            noweZamowienie.UserId = userId;

            db.Zamowienia.Add(noweZamowienie);

            if (noweZamowienie.PozycjeZamowienia == null)
            {
                noweZamowienie.PozycjeZamowienia = new List<PozycjaZamowienia>();
            }

            decimal koszykWartosc = 0;

            foreach (var koszykElement in koszyk)
            {
                var nowaPozycjaZamowniea = new PozycjaZamowienia()
                {
                    KursId = koszykElement.Kurs.KursId,
                    Ilosc = koszykElement.Ilosc,
                    CenaZakupu = koszykElement.Kurs.CenaKursu,

                };
                koszykWartosc += (koszykElement.Ilosc * koszykElement.Kurs.CenaKursu);
                noweZamowienie.PozycjeZamowienia.Add(nowaPozycjaZamowniea);
            }


            noweZamowienie.WartoscZamowienia = koszykWartosc;
            db.SaveChanges();

            return noweZamowienie;
        }


        public void PustyKoszyk()
        {
            session.Set<List<PozycjaKoszyka>>(Consts.KoszykSessionKey, null);
        }
    }
}