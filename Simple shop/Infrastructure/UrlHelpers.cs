using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Simple_shop.Infrastructure
{
    public static class UrlHelpers
    {
        public static string ikonyKategoriiSciezka(this UrlHelper helper, string nazwaIkonyKategorii)
        {
            var IkonyKategoriFolder = AppConfig.IkonyKategoriFolderzgledny;
            var sciezka = Path.Combine(IkonyKategoriFolder, nazwaIkonyKategorii);
            var sciezbkaBezwgledna = helper.Content(sciezka);

            return sciezbkaBezwgledna;
        }
        public static string ObrazkiiiSciezka(this UrlHelper helper, string nazwaObrazka)
        {
            var ObrazkiFolder = AppConfig.ObrazkiKategoriFolderzgledny;
            var sciezka = Path.Combine(ObrazkiFolder, nazwaObrazka);
            var sciezbkaBezwgledna = helper.Content(sciezka);

            return sciezbkaBezwgledna;
        }
    }
}