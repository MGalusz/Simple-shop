namespace Simple_shop.Migrations
{
    using Simple_shop.DAL;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    public sealed class Configuration : DbMigrationsConfiguration<Simple_shop.DAL.CourseContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "Simple_shop.DAL.CourseContext";
        }

        protected override void Seed(Simple_shop.DAL.CourseContext context)
        {
            KursyInitializer.SeedKursyData(context);
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
