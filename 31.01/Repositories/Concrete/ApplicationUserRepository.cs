using _31._01.Areas.Identity.Data;
using _31._01.Areas.Identity.Entities.Concrete;
using _31._01.Data;
using _31._01.Repositories.Abstract;

namespace _31._01.Repositories.Concrete
{
    public class ApplicationUserRepository : GenericRepository<ApplicationUser>, IApplicationUserRepository
    {
        private readonly ApplicationDbContext db;
        public ApplicationUserRepository(ApplicationDbContext db) : base(db)
        {
            this.db = db;
        }
    }
}
