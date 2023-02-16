
namespace _31._01.Areas.Identity.Entities.Concrete
{
    public class Category
    {
        public Category()
        {
            Articles = new HashSet<Article>();
        }
        public int Id { get; set; }
        public string CategoryType { get; set; }
        public ICollection<Article> Articles { get; set; }
    }
}
