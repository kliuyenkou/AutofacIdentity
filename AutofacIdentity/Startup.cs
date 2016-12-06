using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AutofacIdentity.Startup))]
namespace AutofacIdentity
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
