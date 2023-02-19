using _31._01.Areas.Identity.Data;
using _31._01.Areas.Identity.Entities.Concrete;
using _31._01.Models;
using _31._01.Repositories.Abstract;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace _31._01.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly IWriterRepository writerRepository;
        private readonly IArticleRepository articleRepository;
        private readonly ICategoryRepository categoryRepository;
        private readonly IApplicationUserRepository applicationUserRepository;
        public CategoriesController(IWriterRepository writerRepository, IArticleRepository articleRepository, ICategoryRepository categoryRepository, IApplicationUserRepository applicationUserRepository)
        {
            this.writerRepository = writerRepository;
            this.articleRepository = articleRepository;
            this.categoryRepository = categoryRepository;
            this.applicationUserRepository = applicationUserRepository;
        }
        public IActionResult Index()
        {
            var id = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = applicationUserRepository.GetByIdIncludeCategory(id);

            var category = categoryRepository.GetAll();
            CategoriesIndexVM categoriesIndexVM = new CategoriesIndexVM();
            
            categoriesIndexVM.UsersCategories = user.Categories;
            categoriesIndexVM.Categories = category;
            
            
            categoriesIndexVM.UserId = id;
            


            return View(categoriesIndexVM);
        }
        [HttpPost]
        public IActionResult AddCategories(int[] ids, string id)
        {
            var user = applicationUserRepository.GetByIdIncludeCategory(id);

            HashSet<Category> categories = new HashSet<Category>();
            foreach (var item in ids)
            {
                var category = categoryRepository.GetById(item);
                categories.Add(category);
            }
            user.Categories = categories;

            var returner = applicationUserRepository.Update(user);
            return RedirectToAction(nameof(Index));



        }
        public IActionResult GoToArticle(int Id)
        {
            var article = articleRepository.GetAllIncludeCategories(Id);
            ArticlesIndexVM articlesIndexVM = new ArticlesIndexVM();
            articlesIndexVM.Articles = article;
            return View(articlesIndexVM);
        }
        public IActionResult Read(int id)
        {
            var article = articleRepository.GetById(id);
            var user = writerRepository.GetById(article.ApplicationUserID);

            article.Popular++;
            articleRepository.Update(article);

            ArticlesIndexVM articlesIndexVM = new ArticlesIndexVM();
            decimal sayi = article.Content.Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries).Length / 2;

            articlesIndexVM.AvgReadingTime = sayi;
            articlesIndexVM.Content = article.Content;
            articlesIndexVM.Title = article.Name;
            articlesIndexVM.CreatedTime = article.CreatedDate;
            articlesIndexVM.Image = user.Photo;
            articlesIndexVM.Writer = user.FirstName + " " + user.LastName;
            articlesIndexVM.ViewCount = article.Popular;
            articlesIndexVM.UserId = user.Id;
            articlesIndexVM.ArticleId = article.Id;
            return View(articlesIndexVM);

        }
    }
}
