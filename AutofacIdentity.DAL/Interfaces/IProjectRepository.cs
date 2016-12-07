using System.Collections.Generic;
using AutofacIdentity.DAL.Entities;

namespace AutofacIdentity.DAL.Interfaces
{
    public interface IProjectRepository : IRepository<Project>
    {
        IEnumerable<Project> GetProjectsUserCreate(string userId);
    }
}