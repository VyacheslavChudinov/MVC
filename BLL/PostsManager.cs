using System;
using System.Linq;
using DAL;
using WorkingLife = DAL.Models.WorkingLife;

namespace BLL
{
    public class PostsManager
    {
        private readonly IUnitOfWork uow;
        public PostsManager(IUnitOfWork uowInstance)
        {
            uow = uowInstance;
        }

        public ICodeManagerRepository<DAL.Models.Post> GetPosts()
        {
            var result = uow.PostRepository.GetAll().ToList();

            foreach (var post in result)
            {
                if (post.WorkingLife == (WorkingLife) Models.WorkingLife.Forever || post.CreationDate.GetValueOrDefault().AddDays((int) post.WorkingLife) >= DateTime.Now) continue;
                uow.PostRepository.Delete(post.Id);
                uow.Commit();
            }

            return uow.PostRepository;
        }
    }
}
