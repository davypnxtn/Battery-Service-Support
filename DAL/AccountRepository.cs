using DAL.Interfaces;
using Microsoft.AspNetCore.Identity;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class AccountRepository : IAccountRepository
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;

        public AccountRepository(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        public List<ApplicationUser> GetUsers()
        {
            return userManager.Users.ToList();
        }

        public async Task<SignInResult> Login(string username, string password, bool rememberMe)
        {
            return await signInManager.PasswordSignInAsync(username, password, rememberMe, false);
        }

        public void Logout()
        {
            signInManager.SignOutAsync();
        }

        public async Task<IdentityResult> Register(ApplicationUser user, string password)
        {
            return await userManager.CreateAsync(user, password);
        }

        public async Task<ApplicationUser> FindById(string id)
        {
            return await userManager.FindByIdAsync(id);
        }

        public async Task<Boolean> IsInRole(ApplicationUser user, string name)
        {
            return await userManager.IsInRoleAsync(user, name);
        }

        public async Task<IdentityResult> AddToRole(ApplicationUser user, string roleName)
        {
            return await userManager.AddToRoleAsync(user, roleName);
        }

        public async Task<IdentityResult> RemoveFromRole(ApplicationUser user, string roleName)
        {
            return await userManager.RemoveFromRoleAsync(user, roleName);
        }

        public async Task<IList<string>> GetUserRoles(ApplicationUser user)
        {
            return await userManager.GetRolesAsync(user);
        }

        public async Task<IdentityResult> EditUser(ApplicationUser user)
        {
            return await userManager.UpdateAsync(user);
        }

        public async Task<IdentityResult> DeleteUser(ApplicationUser user)
        {
            return await userManager.DeleteAsync(user);
        }

        public async Task<IdentityResult> RemoveFromRoles(ApplicationUser user, IList<string> roles)
        {
            return await userManager.RemoveFromRolesAsync(user, roles);
        }

        public async Task<IdentityResult> AddToRoles(ApplicationUser user, IList<string> roles)
        {
            return await userManager.AddToRolesAsync(user, roles);
        }
    }
}
