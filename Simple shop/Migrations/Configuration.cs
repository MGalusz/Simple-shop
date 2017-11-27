using Simple_shop.DAL;

namespace Simple_shop.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    public sealed class Configuration : DbMigrationsConfiguration<Simple_shop.DAL.KursyContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Simple_shop.DAL.KursyContext context)
        {
            KursyInitializer.SeedKursyData(context);
            KursyInitializer.SeedUzytkownicy(context);
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
