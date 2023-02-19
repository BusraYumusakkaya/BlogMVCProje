using _31._01.Areas.Identity.Data;
using _31._01.Areas.Identity.Entities.Concrete;

namespace _31._01.Repositories.Abstract
{
    public interface IApplicationUserRepository : IRepository<ApplicationUser>
    {
        public ApplicationUser GetById(string id);
        IEnumerable<ApplicationUser> GetAllIncludeCategories();
        ApplicationUser GetByIdIncludeCategory(string id);
    }
}
