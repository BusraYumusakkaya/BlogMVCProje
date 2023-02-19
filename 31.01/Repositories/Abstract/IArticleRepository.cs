using _31._01.Areas.Identity.Entities.Concrete;
using _31._01.Repositories.Abstract;

namespace _31._01.Repositories.Abstract
{
    public interface IArticleRepository : IRepository<Article>
    {
        Article GetByIdIncludeCategory(int id);
        IEnumerable<Article> GetAllIncludeUsers();
        IEnumerable<Article> GetAllIncludeCategories();
        IEnumerable<Article> GetAllIncludeCategories(int Id);
    }
}
