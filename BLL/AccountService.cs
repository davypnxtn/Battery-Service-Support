using BLL.Interfaces;
using DAL.Interfaces;
using Microsoft.AspNetCore.Identity;
using Model;
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

        // ----- Deactiveren gebruiker in database -----
        public async Task<IdentityResult> DisableUser(ApplicationUser user)
        {
            user.Aktief = false;
            return await repository.EditUser(user);
        }

        // ----- Zoek gebruiker op naam -----
        public async Task<ApplicationUser> FindByName(string name)
        {
            return await repository.FindByName(name);
        }

        // ----- Login -----
        public async Task<(SignInResult, bool)> Login(LoginViewModel model)
        {
            ApplicationUser user = await FindByName(model.UserName);

            // Controle of gebruiker bestaat in de database
            if (user == null)
            {
                return (SignInResult.Failed, false);
            }

            SignInResult result;

            bool isAdmin = await CheckRole(user, "Administrator");
            
            // Controle of de User actief is.
            if (user.Aktief)
            {
                result = await repository.Login(model.UserName, model.Password, model.RememberMe);

                // Indien er 5 verkeerde Login pogingen na elkaar zijn. Gebruiker deactiveren in database
                if (result.IsLockedOut)
                {
                    _ = await DisableUser(user);
                }
            }
            else
            {
                result = SignInResult.NotAllowed;
            }
            
            return (result, isAdmin);
        }

        // ----- Logout -----
        public void Logout()
        {
            repository.Logout();
        }

        // ----- Registreren nieuwe User -----
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

        // ----- Controle of een User aan een bepaalde Role is toegewezen -----
        public async Task<bool> CheckRole(ApplicationUser user, string roleName)
        {
            return await repository.IsInRole(user, roleName);
        }
    }
}
