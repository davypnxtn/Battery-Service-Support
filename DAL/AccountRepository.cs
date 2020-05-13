using DAL.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
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

        // ----- Opvragen alle gebruikers ------
        public List<ApplicationUser> GetUsers()
        {
            return userManager.Users.ToList();
        }

        // ----- Login -----
        public async Task<SignInResult> Login(string username, string password, bool rememberMe)
        {
            return await signInManager.PasswordSignInAsync(username, password, rememberMe, true);
        }

        // ----- Logout -----
        public void Logout()
        {
            signInManager.SignOutAsync();
        }

        // ----- Registreren nieuwe User -----
        public async Task<IdentityResult> Register(ApplicationUser user, string password)
        {
            return await userManager.CreateAsync(user, password);
        }

        // ----- Zoek gebruiker op userId -----
        public async Task<ApplicationUser> FindById(string id)
        {
            return await userManager.FindByIdAsync(id);
        }

        // ----- Zoek gebruiker op naam -----
        public async Task<ApplicationUser> FindByName(string name)
        {
            return await userManager.FindByNameAsync(name);
        }

        // ----- Controle of een User aan een bepaalde Role is toegewezen -----
        public async Task<Boolean> IsInRole(ApplicationUser user, string name)
        {
            return await userManager.IsInRoleAsync(user, name);
        }

        // ----- Gebruiker toevoegen aan een bepaalde Role -----
        public async Task<IdentityResult> AddToRole(ApplicationUser user, string roleName)
        {
            return await userManager.AddToRoleAsync(user, roleName);
        }

        // ----- Gebruiker verwijderen van een bepaalde Role -----
        public async Task<IdentityResult> RemoveFromRole(ApplicationUser user, string roleName)
        {
            return await userManager.RemoveFromRoleAsync(user, roleName);
        }

        // ----- Opvragen Rollen van gebruiker -----
        public async Task<IList<string>> GetUserRoles(ApplicationUser user)
        {
            return await userManager.GetRolesAsync(user);
        }

        // ----- Updaten gebruiker gegevens -----
        public async Task<IdentityResult> EditUser(ApplicationUser user)
        {
            return await userManager.UpdateAsync(user);
        }

        // ----- Verwijderen gebruiker -----
        public async Task<IdentityResult> DeleteUser(ApplicationUser user)
        {
            try
            {
                return await userManager.DeleteAsync(user);
            }
            catch (DbUpdateException)
            {
                throw;
            }
        }

        // ----- Gebruiker verwijderen van een Lijst van Rollen -----
        public async Task<IdentityResult> RemoveFromRoles(ApplicationUser user, IList<string> roles)
        {
            return await userManager.RemoveFromRolesAsync(user, roles);
        }

        // ----- Gebruiker toevoegen aan een Lijst van Rollen -----
        public async Task<IdentityResult> AddToRoles(ApplicationUser user, IList<string> roles)
        {
            return await userManager.AddToRolesAsync(user, roles);
        }
    }
}
