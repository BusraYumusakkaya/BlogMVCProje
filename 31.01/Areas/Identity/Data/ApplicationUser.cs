using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using _31._01.Areas.Identity.Entities.Concrete;
using Microsoft.AspNetCore.Identity;

namespace _31._01.Areas.Identity.Data;

// Add profile data for application users by adding properties to the _31_01User class
public class ApplicationUser : IdentityUser
{
    public ApplicationUser()
    {
        Articles=new HashSet<Article>();
    }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string? İnformation { get; set; }
    public string? Photo { get; set; }
    public ICollection<Article>Articles { get; set; }
}

