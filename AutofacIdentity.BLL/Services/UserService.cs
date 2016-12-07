using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutofacIdentity.BLL.Infrastructure;
using AutofacIdentity.BLL.Interfaces;
using AutofacIdentity.BLL.Models;
using AutofacIdentity.DAL.Entities;
using AutofacIdentity.DAL.Interfaces;
using Microsoft.AspNet.Identity;


namespace AutofacIdentity.BLL.Services
{
    public class UserService : IUserService
    {
        private IUnitOfWork _unitOfWork;
        private IUserManager<ApplicationUser> _userManager;
        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _userManager = unitOfWork.UserManager;
        }
        public async Task<OperationResult> CreateAsync(User user)
        {
            ApplicationUser appUser = await _userManager.FindByEmailAsync(user.Email);
            if (appUser == null) {
                appUser = new ApplicationUser { Email = user.Email, UserName = user.Email, Name = user.Name };
                var result = await _userManager.CreateAsync(appUser, user.Password);
                await _unitOfWork.SaveChangesAsync();
                return new OperationResult(true, "You have been successfully registered!", "");
            }
            else {
                return new OperationResult(false, "User with this email already exist!", "");
            }
        }

        public async Task<ClaimsIdentity> SignInAsync(User user)
        {
            ClaimsIdentity claim = null;
            ApplicationUser appUser = await _userManager.FindAsync(user.Email, user.Password);

            if (appUser != null)
                claim = await _userManager.CreateIdentityAsync(appUser,
                                            DefaultAuthenticationTypes.ApplicationCookie);
            return claim;
        }
    }
}
