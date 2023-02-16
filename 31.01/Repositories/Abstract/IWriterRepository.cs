using _31._01.Areas.Identity.Data;
using _31._01.Areas.Identity.Entities.Concrete;
using _31._01.Repositories.Abstract;

namespace _31._01.Repositories.Abstract
{
    public interface IWriterRepository : IRepository<ApplicationUser>
    {
        ApplicationUser GetById(string Id);
        IEnumerable<ApplicationUser> GetAllIncludeArticle();
        ApplicationUser GetByIdIncludeArticle(string id);
    }
}
