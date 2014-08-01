using DAL.Models;

namespace DAL.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<UnitOfWork>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(UnitOfWork context)
        {
            context.Languages.AddOrUpdate(l => l.Name,
                new Language{Name = "C#"},
                new Language{Name = "Java"},
                new Language{Name = "JavaScript"},
                new Language{Name = "Pascal"},
                new Language{Name = "Python"},
                new Language{Name = "Ruby"},
                new Language{Name = "Haskell"},
                new Language{Name = "Fortran"},
                new Language{Name = "Assembler"}
                );
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
        }
    }
}
