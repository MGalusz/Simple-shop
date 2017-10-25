using System.Collections;
using System.Collections.Generic;

namespace Simple_shop.Models
{
    public class Category
    {
        public int  CategoryId { get; set; }
        public string nameCategory { get; set; }
        public string DescCategory { get; set; }
        public string FileNameIcons { get; set; }

        public virtual ICollection<Course> Coursy { get; set; }
    }
}