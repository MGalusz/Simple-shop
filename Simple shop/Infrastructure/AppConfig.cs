using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace Simple_shop.Infrastructure
{
    public class AppConfig
    {
        private static string _ikonyKategoriFolderzgledny = ConfigurationManager.AppSettings["IkonyKategoriiFolder"];

        public static string IkonyKategoriFolderzgledny
        {
            get
            {
                return _ikonyKategoriFolderzgledny;
            }
        }        private static string _obrazkiKategoriFolderzgledny = ConfigurationManager.AppSettings["obrazkiFolder"];

        public static string ObrazkiKategoriFolderzgledny
        {
            get
            {
                return _obrazkiKategoriFolderzgledny;
            }
        }



    }
}