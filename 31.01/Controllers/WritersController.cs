using _31._01.Areas.Identity.Data;
using _31._01.Areas.Identity.Entities.Concrete;
using _31._01.Models;
using _31._01.Repositories.Abstract;
using _31._01.Repositories.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace _31._01.Controllers
{
    public class WritersController : Controller
    {
        private readonly IWriterRepository writerRepository;
        private readonly IArticleRepository articleRepository;
        private readonly ICategoryRepository categoryRepository;
        private readonly IApplicationUserRepository applicationUserRepository;
        public WritersController(IWriterRepository writerRepository, IArticleRepository articleRepository,ICategoryRepository categoryRepository,IApplicationUserRepository applicationUserRepository)
        {
            this.writerRepository = writerRepository;
            this.articleRepository = articleRepository; 
            this.categoryRepository = categoryRepository;
            this.applicationUserRepository = applicationUserRepository;
        }
        public IActionResult Index()
        {
            var writers = writerRepository.GetAll();
            WritersIndexVM writersIndexVM = new WritersIndexVM();
            writersIndexVM.ApplicationUsers=writers;
            return View(writersIndexVM);
        }
        public IActionResult Profile(string id)
        {
            var user = writerRepository.GetByIdIncludeArticle(id);
            WriterProfileVm writerProfileVM = new WriterProfileVm();
            writerProfileVM.FirstName = user.FirstName;
            writerProfileVM.LastName = user.LastName;
            writerProfileVM.Id = user.Id;
            writerProfileVM.Email= user.Email;
            writerProfileVM.Articles =user.Articles;
            if (user.İnformation != null)
            {
                writerProfileVM.İnformation = user.İnformation;
            }
            if (user.Photo != null)
            {
                writerProfileVM.Photo = user.Photo;
            }

            return View(writerProfileVM);
        }
        public IActionResult AddArticle(string id)
        {
            AddArticleVM addArticleVM = new AddArticleVM();
            addArticleVM.UserId = id;
            return View(addArticleVM);
        }
        [HttpPost]
        public IActionResult AddArticle(AddArticleVM addArticleVM)
        {
            Article article = new Article();
            article.Content = addArticleVM.Content;
            article.ApplicationUserID = addArticleVM.UserId;
            article.Name = addArticleVM.Name;
            article.Popular = 0;
            articleRepository.Add(article);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Delete(int id)
        {
            var data = articleRepository.GetById(id);
            if (data != null)
            {
                bool returner = articleRepository.Delete(data);
                TempData["msg"] = "The article has been deleted!";
            }
            return RedirectToAction(nameof(Index));
        }
        public IActionResult ChooseCategory(int id)
        {
            
            var article = articleRepository.GetByIdIncludeCategory(id);

            var category = categoryRepository.GetAll();
            ChooseCategoryVM chooseCategoryVM = new ChooseCategoryVM();
            chooseCategoryVM.Categories = category;
            chooseCategoryVM.ArticleId = id;
            chooseCategoryVM.ArticlesCategory = article.Categories;
            return View(chooseCategoryVM);


        }
        [HttpPost]
        public IActionResult ChooseCategory(int[] ids, int id)
        {
            var article = articleRepository.GetByIdIncludeCategory(id);

            HashSet<Category> categories = new HashSet<Category>();
            foreach (var item in ids)
            {
                var category = categoryRepository.GetById(item);
                categories.Add(category);
            }
            article.Categories = categories;

            var returner = articleRepository.Update(article);
            return RedirectToAction(nameof(Index));



        }
        [HttpPost]
        public IActionResult AddInformation(WriterProfileVm writerProfileVm)
        {
            ApplicationUser applicationUser = new ApplicationUser();
            applicationUser.Id = writerProfileVm.Id;
            applicationUser.FirstName = writerProfileVm.FirstName;
            applicationUser.LastName = writerProfileVm.LastName;
            applicationUser.Email = writerProfileVm.Email;
            if (applicationUser.Photo != null)
            {
                applicationUser.Photo = writerProfileVm.Photo;
            }
            applicationUser.İnformation = writerProfileVm.İnformation;

            applicationUserRepository.Update(applicationUser);
            return RedirectToAction(nameof(Index));
        }
    }
}
