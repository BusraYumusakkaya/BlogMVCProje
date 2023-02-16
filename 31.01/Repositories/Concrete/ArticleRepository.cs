using _31._01.Areas.Identity.Entities.Concrete;
using _31._01.Data;
using _31._01.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace _31._01.Repositories.Concrete
{
    public class ArticleRepository : GenericRepository<Article>, IArticleRepository
    {
        private readonly ApplicationDbContext db;
        public ArticleRepository(ApplicationDbContext db) : base(db)
        {
            this.db = db;
        }
        public Article GetByIdIncludeCategory(int id)
        {
            return db.Articles.Include(s => s.Categories).FirstOrDefault(s => s.Id == id);
        }
        public IEnumerable<Article> GetAllIncludeUsers()
        {
            return db.Articles.Include(s => s.ApplicationUser).Include(a=>a.Categories).OrderByDescending(a=>a.Popular);
        }

        public IEnumerable<Article> GetAllIncludeCategories()
        {
            return db.Articles.Include(s => s.Categories);
        }
        //public IEnumerable<Article> FindTopicFromArticle(string input)
        //{
        //    return db.Articles.Where(a => a.Id == input);
        //}
    }
}
