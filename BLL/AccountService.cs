using BLL.Interfaces;
using DAL.Interfaces;
using Microsoft.AspNetCore.Identity;
using Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ViewModel;

namespace BLL
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository repository;

        public AccountService(IAccountRepository _repository)
        {
            repository = _repository;
        }

        public async Task<SignInResult> Login(LoginViewModel model)
        {
            SignInResult result = await repository.Login(model.UserName, model.Password, model.RememberMe);
            return result;
        }

        public void Logout()
        {
            repository.Logout();
        }

        public async Task<IdentityResult> Register(RegisterViewModel model)
        {
            ApplicationUser user = new ApplicationUser
            {
                UserName = model.UserName,
                Email = model.Email,
                Naam = model.Naam,
                XjoGebruikerCode = model.XjoGebruikerCode,
                Aktief = false
            };

            IdentityResult result = await repository.Register(user, model.Password);
            return result;
        }
    }
}
