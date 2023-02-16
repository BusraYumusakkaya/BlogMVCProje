using _31._01.Areas.Identity.Data;
using _31._01.Areas.Identity.Entities.Concrete;
using System.ComponentModel.DataAnnotations.Schema;

namespace _31._01.Models
{
    public class WriterProfileVm
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
