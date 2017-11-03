using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Simple_shop.Models;

namespace Simple_shop.ViewModels
{
    public class HomeVM
    {
        public  IEnumerable<Category> kategorie { get; set; }
        public  IEnumerable<Course> Nowosci { get; set; }
        public  IEnumerable<Course> Bestsellery { get; set; }
    }
}