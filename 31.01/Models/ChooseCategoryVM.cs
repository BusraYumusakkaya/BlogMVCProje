using _31._01.Areas.Identity.Entities.Concrete;

namespace _31._01.Models
{
    public class ChooseCategoryVM
    {
        public int ArticleId { get; set; }
        public IEnumerable<Category> Categories { get; set; }
        public IEnumerable<Category> ArticlesCategory { get; set; }
    }
}
