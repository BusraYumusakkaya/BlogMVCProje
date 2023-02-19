using _31._01.Areas.Identity.Data;
using _31._01.Areas.Identity.Entities.Concrete;
using _31._01.Models;
using _31._01.Repositories.Abstract;
using _31._01.Repositories.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Claims;

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
        public IActionResult AddInformation(string id)
        {
            WriterProfileVm writerProfileVm = new WriterProfileVm();
            var user = applicationUserRepository.GetById(id);
            writerProfileVm.Id = user.Id;
            writerProfileVm.FirstName = user.FirstName;
            writerProfileVm.LastName=user.LastName ;
            writerProfileVm.Email=user.Email;
            if (user.Photo != null)
            {
                writerProfileVm.Photo=user.Photo  ;
            }
           writerProfileVm.İnformation= user.İnformation  ;

            return View(writerProfileVm);
        }
        [HttpPost]
        public IActionResult AddInformation(WriterProfileVm writerProfileVm)
        {
            //ApplicationUser applicationUser = new ApplicationUser();
            var user = applicationUserRepository.GetById(writerProfileVm.Id);
            user.Id = writerProfileVm.Id;
            user.İnformation = writerProfileVm.İnformation;

            applicationUserRepository.Update(user);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Setting()
        {
            var id = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = writerRepository.GetById(id);

            SettingVM settingVM = new SettingVM();
            settingVM.Id = user.Id;
            settingVM.FirstName = user.FirstName;
            settingVM.LastName = user.LastName;
            settingVM.Photo = user.Photo;

            ViewData["UserId"] = new SelectList(writerRepository.GetAll(), "Id", "Name");
            return View(settingVM);
        }
        [HttpPost]
        public IActionResult Setting(SettingVM settingVM)
        {
            var user = writerRepository.GetById(settingVM.Id);
            user.Id = settingVM.Id;
            user.FirstName = settingVM.FirstName;
            user.LastName = settingVM.LastName;
            user.Photo = settingVM.Photo;

            writerRepository.Update(user);
            return RedirectToAction(nameof(Index));
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
