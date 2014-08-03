using DAL.Models;
using Microsoft.AspNet.Identity;

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
        }
    }
}
