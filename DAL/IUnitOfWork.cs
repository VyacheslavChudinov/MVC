using DAL.Models;

namespace DAL
{
    public interface IUnitOfWork
    {
        ICodeManagerRepository<ApplicationUser> UserRepository { get;}
        ICodeManagerRepository<Post> PostRepository { get; }
        ICodeManagerRepository<Language> LanguageRepository { get; }
        void Commit();
    }
}
