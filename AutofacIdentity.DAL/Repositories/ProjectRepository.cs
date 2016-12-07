using System.Collections.Generic;
using AutofacIdentity.DAL.Entities;
using AutofacIdentity.DAL.Identity;
using AutofacIdentity.DAL.Interfaces;

namespace AutofacIdentity.DAL.Repositories
{
    public class ProjectRepository : Repository<Project>, IProjectRepository
    {
        public ProjectRepository(ApplicationDbContext context) : base(context)
        {
        }

        public IEnumerable<Project> GetProjectsUserCreate(string userId)
        {
            throw new System.NotImplementedException();
        }
    }
}
