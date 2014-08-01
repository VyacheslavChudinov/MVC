using System;
using System.Linq;
using System.Web.Mvc;
using BLL;
using DAL;
using DAL.Models;
using ListingsManager.ViewModels;
using Microsoft.AspNet.Identity;

namespace ListingsManager.Controllers
{
    [Authorize]
    public class PostController : Controller
    {
        private readonly IUnitOfWork uow;
        private readonly PostsManager postsManager;

        public PostController(IUnitOfWork uowInstance)
        {
            uow = uowInstance;
            postsManager = new PostsManager(uowInstance);
        }
        //
        // GET: /Post/
        public ActionResult Index()
        {
            var posts = postsManager.GetPosts().GetAll().ToList();
            return View(posts);
        }

        public ActionResult AddPost()
        {
            var users = uow.UserRepository;
            var currentUser = users.Get(Guid.Parse(User.Identity.GetUserId()));
            ViewBag.EstimatedPosts = (int)currentUser.AccountType - currentUser.Posts.Count;
            ViewBag.IsAdmin = currentUser.AccountType == AccountType.Administrator;
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        [Authorize]
        public ActionResult AddPost(PostViewModel post)
        {
            var posts = postsManager.GetPosts();
            var users = uow.UserRepository;
            var languages = uow.LanguageRepository;
            var currentUser = users.Get(Guid.Parse(User.Identity.GetUserId()));
            var language = languages.GetAll().FirstOrDefault(l => l.Name.ToLower() == post.Language.ToLower()) ?? new Language
            {
                Name = Char.ToUpper(post.Language[0]) + post.Language.Substring(1).ToLower()
            };

            var newPost = new Post
            {
                Author = users.Get(Guid.Parse(User.Identity.GetUserId())),
                Name = post.Name,
                Content = post.Content,
                Language = language,
                CreationDate = DateTime.Now,
                WorkingLife = post.WorkingLife
            };

            if (currentUser.AccountType != AccountType.Administrator && currentUser.Posts.Count >= (int)currentUser.AccountType)
            {
                var oldestDate = currentUser.Posts.ToList().Min(p => p.CreationDate);
                if (oldestDate != null)
                {
                    posts.Delete(currentUser.Posts.ToList().Find(p => p.CreationDate == oldestDate).Id);
                }
            }
            posts.Insert(newPost);
            uow.Commit();
            
            return RedirectToAction("UserProfile", "Account");
        }

        [Authorize]
        public ActionResult EditPost(Guid id)
        {
            var post = postsManager.GetPosts().Get(id);

            return PartialView("_EditPostPartial", post);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult EditPost(Post newPost)
        {
            var languages = uow.LanguageRepository;
           // var posts = postsManager.GetPosts();
            var updatedPost = uow.PostRepository.Get(newPost.Id);
            var languageIsExist = languages.GetAll()
                .ToList()
                .SingleOrDefault(lang => lang.Name == newPost.Language.Name) != null;

            var languageIsChanged =
                languages.GetAll()
                    .ToList()
                    .Any(lang => lang.Name == newPost.Language.Name && lang.Id == newPost.LanguageId);

            var newLanguage = new Language { Name = Char.ToUpper(newPost.Language.Name[0]) + newPost.Language.Name.Substring(1).ToLower()};
            if(languageIsChanged)
            {
                if (languageIsExist)
                {
                    updatedPost.Language =
                        languages.GetAll().ToList().SingleOrDefault(lang => lang.Name == newPost.Language.Name);
                }
                else
                {
                    languages.Insert(newLanguage);
                    updatedPost.Language = newLanguage;
                }
            }

            updatedPost.WorkingLife = newPost.WorkingLife;
            uow.PostRepository.Update(updatedPost);
            uow.Commit();
            return PartialView("_PostInfoPartial", updatedPost);
        }
    }
}