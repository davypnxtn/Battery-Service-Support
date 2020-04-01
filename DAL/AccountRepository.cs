using DAL.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class AccountRepository : IAccountRepository
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;

        public AccountRepository(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        public async Task<SignInResult> Login(string username, string password, bool rememberMe)
        {
            return await signInManager.PasswordSignInAsync(username, password, rememberMe, false);
        }

        public void Logout()
        {
            signInManager.SignOutAsync();
        }

        public async Task<IdentityResult> Register(IdentityUser user, string password)
        {
            
             return await userManager.CreateAsync(user, password);

        }
    }
}
