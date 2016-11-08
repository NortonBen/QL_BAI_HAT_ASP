namespace QuanLyBaiHat.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Web.Mvc;
    using QuanLyBaiHat.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<QuanLyBaiHat.Models.DataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(QuanLyBaiHat.Models.DataContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            context.Users.AddOrUpdate(
                  p => p.Id,
                  new User
                  {
                      Id = 1,
                      email = "norton0395@gmail.com",
                      password = "admin",
                      username = "admin"
                  }
                );

        }
    }
}
