using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;
using Simple_shop.Models;

namespace Simple_shop.DAL
{
    public class CourseContext : DbContext
    {
        public CourseContext() : base("CoursyContext")
        {
            
        }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Orders> Orderss { get; set; }
        public DbSet<PositionOrder> PositionOrders { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            // using System.Data.Entity.ModelConfigurations;;
            //Wyłacza konwensję, która automatycznie twory liczbe mnoga dla nazw tabel w bazie danych
            // Zamiast Kategorie zostało stowrzona tabela Kateroiesz
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

    }
}