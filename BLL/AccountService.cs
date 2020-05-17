using BLL.Interfaces;
using DAL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Model;
using System.Security.Claims;
using System.Threading.Tasks;
using ViewModel;

namespace BLL
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository repository;
        private readonly IAdministrationRepository administrationRepository;
        private readonly IAuthorizationService authorizationService;

        public AccountService(IAccountRepository _repository, IAdministrationRepository _administrationRepository, IAuthorizationService _authorizationService)
        {
            repository = _repository;
            administrationRepository = _administrationRepository;
            authorizationService = _authorizationService;
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
            bool hasWarningBatteriesClaim = false;

            // Controle of gebruiker bestaat in de database
            if (user == null)
            {
                return (SignInResult.Failed, false);
            }

            SignInResult result;

            var userRoleNames = await repository.GetUserRoles(user);

            foreach (var roleName in userRoleNames)
            {
                IdentityRole role = await administrationRepository.FindByName(roleName);
                var roleClaims = await administrationRepository.GetRoleClaims(role);

               foreach (Claim claim in roleClaims)
                {
                    if (claim.Type == "Warning Batteries")
                    {
                        hasWarningBatteriesClaim = true;
                    }
                }
            }

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

            return (result, hasWarningBatteriesClaim);
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
    }
}
