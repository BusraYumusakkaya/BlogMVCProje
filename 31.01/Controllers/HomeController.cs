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

        public HomeController(ILogger<HomeController> logger, IArticleRepository articleRepository,ICategoryRepository categoryRepository)
        {
            _logger = logger;
            this.articleRepository = articleRepository;  
            this.categoryRepository = categoryRepository;
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
    }
}