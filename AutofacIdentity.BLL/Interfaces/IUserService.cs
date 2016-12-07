using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutofacIdentity.BLL.Infrastructure;
using AutofacIdentity.BLL.Models;

namespace AutofacIdentity.BLL.Interfaces
{
    public interface IUserService
    {
        Task<OperationResult> CreateAsync(User user);
        Task<ClaimsIdentity> SignInAsync(User user);
    }
}
