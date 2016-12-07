using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using AutofacIdentity.BLL.Identity;
using AutofacIdentity.DAL.Identity;
using Microsoft.AspNet.Identity;

namespace AutofacIdentity.BLL.Autofac
{
    public class BLLModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ApplicationDbContext>().AsSelf().InstancePerRequest();
            builder.RegisterType<ApplicationUserStore>().As<IUserStore<ApplicationUser>>().InstancePerRequest();
            builder.RegisterType<ApplicationUserManager>().AsSelf().InstancePerRequest();
            builder.RegisterType<ApplicationSignInManager>().AsSelf().InstancePerRequest();
            builder.RegisterType<ApplicationUserManager>().As<IApplicationUserManager>().InstancePerRequest();
            builder.RegisterType<ApplicationSignInManager>().As<IApplicationSignInManager>().InstancePerRequest();

        }

    }
}
