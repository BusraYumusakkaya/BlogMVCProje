using _31._01.Areas.Identity.Entities.Concrete;

namespace _31._01.Models
{
    public class ProfileVM
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string İnformation { get; set; }
        public string Photo { get; set; }
        public string Email { get; set; }
        public IEnumerable<Article> Articles { get; set; }
    }
}
