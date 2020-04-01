using Microsoft.AspNetCore.Identity;
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
        Task<SignInResult> Login(LoginViewModel model);
    }
}
