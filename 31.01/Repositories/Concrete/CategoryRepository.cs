using _31._01.Areas.Identity.Entities.Concrete;
using _31._01.Data;
using _31._01.Repositories.Abstract;

namespace _31._01.Repositories.Concrete
{
	public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
	{
        private readonly ApplicationDbContext db;
        public CategoryRepository(ApplicationDbContext db) : base(db)
		{
			this.db = db;
		}
	}
}
