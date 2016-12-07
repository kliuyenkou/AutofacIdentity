using Microsoft.AspNet.Identity.EntityFramework;

namespace AutofacIdentity.BLL.Identity
{
    public class ApplicationUserStore : UserStore<ApplicationUser>
    {
        public ApplicationUserStore(ApplicationDbContext context)
            : base(context)
        {

        }
    }
}