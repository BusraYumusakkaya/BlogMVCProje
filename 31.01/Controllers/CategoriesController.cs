using _31._01.Areas.Identity.Entities.Concrete;
using _31._01.Models;
using _31._01.Repositories.Abstract;
using Microsoft.AspNetCore.Mvc;

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
        public IActionResult Index(string id)
        {
            var user = applicationUserRepository.GetByIdIncludeCategory(id);

            var category = categoryRepository.GetAll();
            CategoriesIndexVM categoriesIndexVM = new CategoriesIndexVM();
            categoriesIndexVM.Categories = category;
            categoriesIndexVM.UserId = id;
            categoriesIndexVM.UsersCategories = user.Categories;
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
    }
}
