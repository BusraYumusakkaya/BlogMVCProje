using _31._01.Areas.Identity.Data;
using _31._01.Areas.Identity.Entities.Concrete;
using _31._01.Data;
using _31._01.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;

namespace _31._01.Repositories.Concrete
{
    public class WriterRepository : GenericRepository<ApplicationUser>, IWriterRepository
    {
        private readonly ApplicationDbContext db;
        public WriterRepository(ApplicationDbContext db) : base(db)
        {
            this.db = db;
        }
        public ApplicationUser GetById(string Id)
        {
            return db.ApplicationUsers.FirstOrDefault(a => a.Id == Id);
        }

        public IEnumerable<ApplicationUser> GetAllIncludeArticle()
        {
            return db.ApplicationUsers.Include(s => s.Articles);
        }

        public ApplicationUser GetByIdIncludeArticle(string id)
        {
            return db.ApplicationUsers.Include(s => s.Articles).ThenInclude(a=>a.Categories).FirstOrDefault(s => s.Id == id);
        }
    }
}
