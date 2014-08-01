using System;
using System.Linq;
using DAL;
using DAL.Models;

namespace BLL
{
    public class PostsManager
    {
        private readonly IUnitOfWork uow;
        public PostsManager(IUnitOfWork uowInstance)
        {
            uow = uowInstance;
        }

        public ICodeManagerRepository<Post> GetPosts()
        {
            var result = uow.PostRepository.GetAll().ToList();
            foreach (var post in result)
            {
                if (post.WorkingLife == WorkingLife.Forever || post.CreationDate.GetValueOrDefault().AddDays((int) post.WorkingLife) >= DateTime.Now) continue;
                uow.PostRepository.Delete(post.Id);
                uow.Commit();
            }

            return uow.PostRepository;
        }
    }
}
