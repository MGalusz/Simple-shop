using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Simple_shop.Models;

namespace Simple_shop.ViewModels
{
    public class EditKursVM
    {
        
        public Kurs Kurs { get; set; }
        public IEnumerable<Kategoria> Kategorie { get; set; }
        public bool? Potwierdzenie { get; set; }
    
}
}