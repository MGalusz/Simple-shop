using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Simple_shop.Models
{
    public class Category
    {
        public int  CategoryId { get; set; }
        [Required(ErrorMessage = "Wprowadz nazwę kategorii")]
        [StringLength(100)]
        public string nameCategory { get; set; }
        [Required(ErrorMessage = "Wprowadz opis kategorii")]
        public string DescCategory { get; set; }
        public string FileNameIcons { get; set; }

        public virtual ICollection<Course> Coursy { get; set; }
    }
}