using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Simple_shop.Models;

namespace Simple_shop.ViewModels
{
    public class HomeVM
    {
        public  IEnumerable<Kategoria> kategorie { get; set; }
        public  IEnumerable<Kurs> Nowosci { get; set; }
        public  IEnumerable<Kurs> Bestsellery { get; set; }
    }
}