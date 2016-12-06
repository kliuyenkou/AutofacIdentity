using AutofacIdentity.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace AutofacIdentity.Identity
{
    public class ApplicationUserStore : UserStore<ApplicationUser>
    {
        public ApplicationUserStore(ApplicationDbContext context)
            : base(context)
        {

        }
    }
}