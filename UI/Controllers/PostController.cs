using System;
using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using BLL;
using DAL;
using DAL.Models;
using ListingsManager.ViewModels;
using Microsoft.AspNet.Identity;

namespace ListingsManager.Controllers
{    
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

        [Authorize]
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
        public ActionResult AddPost(PostViewModel postViewModel)
        {
            var posts = postsManager.GetPosts();
            var users = uow.UserRepository;
            var languages = uow.LanguageRepository;
            var currentUser = users.Get(Guid.Parse(User.Identity.GetUserId()));
            var language = languages.GetAll().FirstOrDefault(l => l.Name.ToLower() == postViewModel.Language.Name.ToLower()) ?? new Language
            {
                Name = Char.ToUpper(postViewModel.Language.Name[0]) + postViewModel.Language.Name.Substring(1).ToLower()
            };
            postViewModel.Author = currentUser;
            postViewModel.Language = language;
            var post = Mapper.Map<Post>(postViewModel);

            if (currentUser.AccountType != AccountType.Administrator && currentUser.Posts.Count >= (int)currentUser.AccountType)
            {
                var oldestDate = currentUser.Posts.ToList().Min(p => p.CreationDate);
                if (oldestDate != null)
                {
                    posts.Delete(currentUser.Posts.ToList().Find(p => p.CreationDate == oldestDate).Id);
                }
            }
            currentUser.Posts.Add(post);
            uow.Commit();

            return RedirectToAction("UserProfile", "Account");
        }

        [Authorize]
        public ActionResult EditPost(Guid id)
        {
            var post = postsManager.GetPosts().Get(id);
            var postViewModel = Mapper.Map<PostViewModel>(post);

            return PartialView("_EditPostPartial", postViewModel);
        }

        [HttpPost]
        [ValidateInput(false)]
        [Authorize]
        public ActionResult EditPost(PostViewModel newPost)
        {
            var languages = uow.LanguageRepository;
            var updatedPost = uow.PostRepository.Get(newPost.Id);
            var languageIsExist = languages.GetAll()
                .ToList()
                .SingleOrDefault(lang => lang.Name == newPost.Language.Name) != null;

            var languageIsChanged =
                languages.GetAll()
                    .ToList()
                    .Any(lang => lang.Name == newPost.Language.Name && lang.Id == newPost.LanguageId);

            var newLanguage = new Language
            {
                Name = Char.ToUpper(newPost.Language.Name[0]) + newPost.Language.Name.Substring(1).ToLower()
            };

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
            updatedPost.Name = newPost.Name;
            updatedPost.Content = newPost.Content;

            uow.Commit();
            return PartialView("_PostInfoPartial", updatedPost);
        }
    }
}