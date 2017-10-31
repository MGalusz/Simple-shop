using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Simple_shop.Models;
using Simple_shop.Migrations;
using System.Data.Entity.Migrations;

namespace Simple_shop.DAL
{
    public class KursyInitializer  : MigrateDatabaseToLatestVersion<CourseContext, Configuration>
    {


        public static void SeedKursyData(CourseContext context)
        {
            var katerogie = new List<Category>
            {
                new Category()
                {
                    CategoryId = 1,
                    nameCategory = "asp",
                    FileNameIcons = "Asp.png",
                    DescCategory = "opis asp ney mvc"
                },
                new Category()
                {
                    CategoryId = 2,
                    nameCategory = "Java",
                    FileNameIcons = "Java.png",
                    DescCategory = "opis Java"
                },
                new Category()
                {
                    CategoryId = 3,
                    nameCategory = "php",
                    FileNameIcons = "php.png",
                    DescCategory = "opis php"
                },
                new Category()
                {
                    CategoryId = 4,
                    nameCategory = "html",
                    FileNameIcons = "html.png",
                    DescCategory = "opis html"
                },
                new Category()
                {
                    CategoryId = 4,
                    nameCategory = "Css",
                    FileNameIcons = "Css.png",
                    DescCategory = "opis Css"
                },
                new Category()
                {
                    CategoryId = 4,
                    nameCategory = "xml",
                    FileNameIcons = "xml.png",
                    DescCategory = "opis xml"
                },
                new Category() {CategoryId = 4, nameCategory = "C#", FileNameIcons = "C#.png", DescCategory = "C# xml"},


            };


            katerogie.ForEach(k => context.Categories.AddOrUpdate(k));
            context.SaveChanges();


            var kursy  = new List<Course>
            {
                new Course(){AuthorCourse = "Tomek", TitleCourse = "Asp.net mvc",CategoryId = 1,Price = 99 , Bestseller = true , ImgName = "asp.jpg",
                    AddDate = DateTime.Now, Desc = "opis Kursu"},
                new Course(){AuthorCourse = "Jacek", TitleCourse = "Asp.net mvc2",CategoryId = 1,Price = 100 , Bestseller = true , ImgName = "asp.jpg",
                    AddDate = DateTime.Now, Desc = "opis Kursu"},
                new Course(){AuthorCourse = "Irek", TitleCourse = "Asp.net mvc1",CategoryId = 1,Price = 120 , Bestseller = true , ImgName = "asp.jpg",
                    AddDate = DateTime.Now, Desc = "opis Kursu"},
                new Course(){AuthorCourse = "romek", TitleCourse = "Asp.net mvc4",CategoryId = 1,Price = 150 , Bestseller = true , ImgName = "asp.jpg",
                    AddDate = DateTime.Now, Desc = "opis Kursu"},

            };

            kursy.ForEach(k => context.Courses.AddOrUpdate(k));
            context.SaveChanges();
        }
    }
}