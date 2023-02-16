using _31._01.Areas.Identity.Entities.Concrete;

namespace _31._01.Models
{
    public class AddArticleVM
    {
        public string? Name { get; set; }
        public string? Content { get; set; }

        public string UserId { get; set; }
        public int CategoryId { get; set; }
    }
}
