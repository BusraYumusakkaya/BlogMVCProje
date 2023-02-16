using _31._01.Areas.Identity.Data;
using _31._01.Areas.Identity.Entity.Abstract;

namespace _31._01.Areas.Identity.Entities.Concrete
{
    public class Article:BaseEntity
    {
        public Article()
        {
            Categories = new HashSet<Category>();
        }
        public string Content { get; set; }
        public int? Popular { get; set; }
        public string? ApplicationUserID { get; set; }
        public ApplicationUser? ApplicationUser { get; set; }
        public ICollection<Category> Categories { get; set; }
    }
}
