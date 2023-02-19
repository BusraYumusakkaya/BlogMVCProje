using _31._01.Areas.Identity.Entities.Concrete;

namespace _31._01.Models
{
    public class CategoriesIndexVM
    {
        public IEnumerable<Category> Categories { get; set; }
        public string UserId { get; set; }
        public IEnumerable<Category> UsersCategories { get; set; }
        public string Content { get; set; }
        public string Name { get; set; }
        public string Writer { get; set; }
        public string CreadeDate { get; set; }
        public string View { get; set; }
    }
}
