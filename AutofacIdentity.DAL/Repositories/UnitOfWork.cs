using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutofacIdentity.DAL.Entities;
using AutofacIdentity.DAL.Identity;
using AutofacIdentity.DAL.Interfaces;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace AutofacIdentity.DAL.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            ProjectRepository = new ProjectRepository(_context);
            UserManager = new ApplicationUserManager(new UserStore<ApplicationUser>(_context));

        }
        public IProjectRepository ProjectRepository { get; }
        public IUserManager<ApplicationUser> UserManager { get; }
        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
