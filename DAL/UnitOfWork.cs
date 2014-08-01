using System;
using System.Data.Entity;
using DAL.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace DAL
{
    public class UnitOfWork : IdentityDbContext<ApplicationUser, CustomRole, Guid, CustomUserLogin, CustomUserRole, CustomUserClaim>, IUnitOfWork
    {
        public UnitOfWork()
            : base("DefaultConnection")
        {

        }

        private CodeManagerRepository<ApplicationUser> userRepository;
        private CodeManagerRepository<Post> postRepository;
        private CodeManagerRepository<Language> languageRepository;

        public DbSet<Post> Posts { get; set; }
        public DbSet<Language> Languages { get; set; }      

        public ICodeManagerRepository<ApplicationUser> UserRepository {
            get { return userRepository ?? (userRepository = new CodeManagerRepository<ApplicationUser>(Users)); }

        }
        public ICodeManagerRepository<Post> PostRepository {
            get { return postRepository ?? (postRepository = new CodeManagerRepository<Post>(Posts)); }
        }
        public ICodeManagerRepository<Language> LanguageRepository {
            get { return languageRepository ?? (languageRepository = new CodeManagerRepository<Language>(Languages)); }
        }


        public void Commit()
        {
            SaveChanges();
        }
    }
}
