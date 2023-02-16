using _31._01.Areas.Identity.Entities.Concrete;

namespace _31._01.Models
{
    public class ArticlesIndexVM
    {
        public IEnumerable<Article> Articles { get; set; }
        public int CategoryId { get; set; }
    }
}
