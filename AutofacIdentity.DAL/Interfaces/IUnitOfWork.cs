using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutofacIdentity.DAL.Entities;
using AutofacIdentity.DAL.Identity;

namespace AutofacIdentity.DAL.Interfaces
{
    public interface IUnitOfWork
    {
        IProjectRepository ProjectRepository { get; }
        IUserManager<ApplicationUser> UserManager { get; }
        void SaveChanges();
        Task SaveChangesAsync();
    }
}
