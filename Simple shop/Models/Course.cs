using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Simple_shop.Models
{
    public class Course
    {
        public int CourseId { get; set; }
        public int CategoryId { get; set; }
        public string TitleCourse { get; set; }
        public string AuthorCourse { get; set; }
        public DateTime AddDate { get; set; }
        public string ImgName { get; set; }
        public string Desc { get; set; }
        public decimal Price { get; set; }
        public bool Bestseller { get; set; }
        public bool Hidden { get; set; }

        public virtual  Category Category { get; set; }
    }
}