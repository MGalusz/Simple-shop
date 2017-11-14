using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Simple_shop.Models;

namespace Simple_shop.ViewModels
{
    public class KoszykVM
    {
        public List<PozycjaKoszyka> PozycjeKoszyka {get;set;}
        public decimal CenaCalkowita { get; set; }
    }
}