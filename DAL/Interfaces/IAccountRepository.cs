using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IAccountRepository
    {
        Task<IdentityResult> Register(IdentityUser user, string password);
        void Logout();
        Task<SignInResult> Login(string username, string password, Boolean rememberMe);
    }
}
