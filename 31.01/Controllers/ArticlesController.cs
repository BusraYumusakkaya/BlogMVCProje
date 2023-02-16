using _31._01.Models;
using _31._01.Repositories.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace _31._01.Controllers
{
    public class ArticlesController : Controller
    {

        public readonly IArticleRepository articleRepository;
        public readonly ICategoryRepository categoryRepository;
        public ArticlesController(IArticleRepository articleRepository,ICategoryRepository categoryRepository)
        {
            this.articleRepository = articleRepository;
            this.categoryRepository = categoryRepository;
        }
        public IActionResult Index()
        {
            var articles = articleRepository.GetAllIncludeUsers();
            ArticlesIndexVM articlesIndexVM = new ArticlesIndexVM();
            articlesIndexVM.Articles = articles;
            return View(articlesIndexVM);
        }
        //public IActionResult FindTopic(string input)
        //{
        //    var search=

        //}
        
    }
}
