using _31._01.Areas.Identity.Data;
using _31._01.Areas.Identity.Entities.Concrete;
using _31._01.Data;
using _31._01.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;

namespace _31._01.Repositories.Concrete
{
    public class ApplicationUserRepository : GenericRepository<ApplicationUser>, IApplicationUserRepository
    {
        private readonly ApplicationDbContext db;
        public ApplicationUserRepository(ApplicationDbContext db) : base(db)
        {
            this.db = db;
        }
        public ApplicationUser GetById(string id)
        {
            return db.ApplicationUsers.Find(id);
        }
        public IEnumerable<ApplicationUser> GetAllIncludeCategories()
        {
            return db.ApplicationUsers.Include(s => s.Categories);
        }
        public ApplicationUser GetByIdIncludeCategory(string id)
        {
            return db.ApplicationUsers.Include(s => s.Categories).FirstOrDefault(s => s.Id == id);
        }
    }
}
