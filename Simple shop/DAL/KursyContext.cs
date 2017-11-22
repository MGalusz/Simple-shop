using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;
using Simple_shop.Models;

namespace Simple_shop.DAL
{
    public class KursyContext : IdentityDbContext<ApplicationUser>
    {
        public KursyContext() : base("KursyContext")
        {
            
        }

        static KursyContext()
        {
            Database.SetInitializer<KursyContext>(new KursyInitializer());
        }

        public static KursyContext Create()
        {
            return new KursyContext();
        }

        public virtual DbSet<Kurs> Kursy { get; set; }
        public virtual DbSet<Kategoria> Kategorie { get; set; }
        public virtual DbSet<Zamowienie> Zamowienia { get; set; }
        public DbSet<PozycjaZamowienia> PozycjeZamowienia { get; set; }

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