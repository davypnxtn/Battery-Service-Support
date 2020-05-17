using Microsoft.AspNetCore.Identity;
using Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ViewModel;

namespace BLL.Interfaces
{
    public interface IAccountService
    {
        Task<IdentityResult> Register(RegisterViewModel model);
        void Logout();
        Task<(SignInResult, bool)> Login(LoginViewModel model);
        //Task<Boolean> CheckRole(ApplicationUser user, string roleName);
        Task<ApplicationUser> FindByName(string name);
        Task<IdentityResult> DisableUser(ApplicationUser user);
    }
}
