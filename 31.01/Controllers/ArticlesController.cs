using _31._01.Models;
using _31._01.Repositories.Abstract;
using _31._01.Repositories.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace _31._01.Controllers
{
    public class ArticlesController : Controller
    {

        public readonly IArticleRepository articleRepository;
        public readonly ICategoryRepository categoryRepository;
        public readonly IWriterRepository writerRepository;
        public ArticlesController(IArticleRepository articleRepository,ICategoryRepository categoryRepository, IWriterRepository writerRepository)
        {
            this.articleRepository = articleRepository;
            this.categoryRepository = categoryRepository;
            this.writerRepository = writerRepository;
        }
        public IActionResult Index()
        {
            var articles = articleRepository.GetAllIncludeUsers();
            ArticlesIndexVM articlesIndexVM = new ArticlesIndexVM();
            articlesIndexVM.Articles = articles;
            return View(articlesIndexVM);
        }
        public IActionResult Read(int id)
        {
            var article = articleRepository.GetById(id);
            var user = writerRepository.GetById(article.ApplicationUserID);

            article.Popular++;
            articleRepository.Update(article);

            ArticlesIndexVM articlesIndexVM = new ArticlesIndexVM();
            decimal sayi = article.Content.Length / 200;

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
