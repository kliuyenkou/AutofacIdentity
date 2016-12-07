using System.Threading.Tasks;
using AutofacIdentity.DAL.Identity;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;

namespace AutofacIdentity.BLL.Identity
{
    public class ApplicationSignInManager : SignInManager<ApplicationUser, string>, IApplicationSignInManager
    {
        public ApplicationSignInManager(ApplicationUserManager userManager, IAuthenticationManager authenticationManager)
            : base(userManager, authenticationManager)
        {
        }

        //public override Task<ClaimsIdentity> CreateUserIdentityAsync(ApplicationUser user)
        //{
        //    return user.GenerateUserIdentityAsync((ApplicationUserManager)UserManager);
        //}

        //public static ApplicationSignInManager Create(IdentityFactoryOptions<ApplicationSignInManager> options, IOwinContext context)
        //{
        //    return new ApplicationSignInManager(context.GetUserManager<ApplicationUserManager>(), context.Authentication);
        //}


        public async Task SignInByEmailAsync(string email, string password, bool isPersistent, bool rememberBrowser)
        {
            ApplicationUser user = new ApplicationUser() { Email = email, PasswordHash = password };
            await SignInAsync(user, isPersistent, rememberBrowser);
        }

        public async Task<IdentityResult> RegisterUser(string email, string password, bool isPersistent, bool rememberBrowser)
        {
            ApplicationUser user = new ApplicationUser() { Email = email, UserName = email};
            var result = await UserManager.CreateAsync(user, password);
            if (result.Succeeded)
            {
                await SignInAsync(user, isPersistent: false, rememberBrowser: false);
            }
            return result;
        }
    }
}