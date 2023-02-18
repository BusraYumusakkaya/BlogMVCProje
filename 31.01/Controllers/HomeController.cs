using _31._01.Areas.Identity.Entities.Concrete;
using _31._01.Models;
using _31._01.Repositories.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;

namespace _31._01.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IArticleRepository articleRepository;
        private readonly ICategoryRepository categoryRepository;
        private readonly IWriterRepository writerRepository;


        public HomeController(ILogger<HomeController> logger, IArticleRepository articleRepository,ICategoryRepository categoryRepository,IWriterRepository writerRepository)
        {
            _logger = logger;
            this.articleRepository = articleRepository;  
            this.categoryRepository = categoryRepository;
            this.writerRepository = writerRepository;
        }

        public IActionResult Index()
        {
            //var categories=articleRepository.GetAllIncludeCategories();
            var articles = articleRepository.GetAllIncludeUsers();
            ArticlesIndexVM articlesIndexVM = new ArticlesIndexVM();
            //articlesIndexVM.Articles = categories;
            articlesIndexVM.Articles = articles;
            ViewData["CategoryId"] = new SelectList(categoryRepository.GetAll(), "Id", "CategoryType");
            return View(articlesIndexVM);
        }

        //birinci yol  [Authorize]
        //ikinci yol [Authorize(Policy ="IsAdmin")]//Claim based authorization
        [Authorize(Roles = "Admin")]
        public IActionResult Privacy()
        {
            return View();
        }
        [Authorize]
        public IActionResult OurStory()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public IActionResult Read(int id)
        {
            var article=articleRepository.GetById(id);
            var user = writerRepository.GetById(article.ApplicationUserID);

            article.Popular ++;
            articleRepository.Update(article);

            ArticlesIndexVM articlesIndexVM = new ArticlesIndexVM();
            decimal sayi = article.Content.Length / 200;

            articlesIndexVM.AvgReadingTime = sayi;
            articlesIndexVM.Content=article.Content;
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