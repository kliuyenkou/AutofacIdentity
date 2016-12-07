using Microsoft.AspNet.Identity.EntityFramework;

namespace AutofacIdentity.DAL.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
    }
}