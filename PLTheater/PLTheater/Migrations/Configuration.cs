namespace PLTheater.Migrations
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<PLTheater.Models.DatabaseContex>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "PLTheater.Models.DatabaseContex";
        }

        protected override void Seed(PLTheater.Models.DatabaseContex context)
        {
            DatabaseContex db = new Models.DatabaseContex();

         
            db.Countries.Add(new Country() { Id = 1, Name = "Bangladesh" });
            db.Countries.Add(new Country() { Id = 2, Name = "Bhutan" });

            db.SaveChanges();

        }
    }
}
