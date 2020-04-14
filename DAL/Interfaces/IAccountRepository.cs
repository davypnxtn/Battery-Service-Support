using Microsoft.AspNetCore.Identity;
using Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IAccountRepository
    {
        Task<IdentityResult> Register(ApplicationUser user, string password);
        void Logout();
        Task<SignInResult> Login(string username, string password, Boolean rememberMe);
        List<ApplicationUser> GetUsers();
        Task<ApplicationUser> FindById(string id);
        Task<Boolean> IsInRole(ApplicationUser user, string name);
        Task<IdentityResult> AddToRole(ApplicationUser user, string roleName);
        Task<IdentityResult> RemoveFromRole(ApplicationUser user, string roleName);
        Task<IList<string>> GetUserRoles(ApplicationUser user);
        Task<IdentityResult> EditUser(ApplicationUser user);
        Task<IdentityResult> DeleteUser(ApplicationUser user);
        Task<IdentityResult> RemoveFromRoles(ApplicationUser user, IList<string> roles);
        Task<IdentityResult> AddToRoles(ApplicationUser user, IList<string> roles);
    }
}
