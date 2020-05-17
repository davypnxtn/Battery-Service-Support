using BLL.Interfaces;
using DAL.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using ViewModel;

namespace BLL
{
    public class AdministrationService : IAdministrationService
    {
        private readonly IAdministrationRepository repository;
        private readonly IAccountRepository accountRepository;

        public AdministrationService(IAdministrationRepository _repository,IAccountRepository _accountRepository)
        {
            repository = _repository;
            accountRepository = _accountRepository;
        }

        // ----- Aanmaken nieuwe rol -----
        public async Task<IdentityResult> CreateRole(CreateRoleViewModel model)
        {
            IdentityRole identityRole = new IdentityRole
            {
                Name = model.RoleName
            };

            IdentityResult result = await repository.CreateRole(identityRole);
            
            return result;
        }

        // ----- Zoek op rol id -----
        public async Task<IdentityRole> FindById(string id)
        {
            return await repository.FindById(id);
        }

        // ----- Aanmaken EditRoleViewModel voor EditRole view -----
        public async Task<EditRoleViewModel> CreateEditRoleViewModel(string id)
        {
            IdentityRole role = await FindById(id);

            if (role == null)
            {
                EditRoleViewModel mdl = new EditRoleViewModel
                {
                    Id = "",
                    RoleName = " ",
                    ErrorMessage = $"Role with Id = {id} cannot be found"
                };

                return mdl;
            }

            EditRoleViewModel model = new EditRoleViewModel
            {
                Id = role.Id,
                RoleName = role.Name,
                ErrorMessage = ""
            };

            var listUsers = accountRepository.GetUsers();
            var roleClaims = await repository.GetRoleClaims(role);

            model.Claims = roleClaims.Select(c => c.Value).ToList();

            foreach (var user in listUsers)
            {
                if(await accountRepository.IsInRole(user, role.Name))
                {
                    model.Users.Add(user.Naam);
                }
            }

            return model;
        }

        // ----- Aanmaken RoleUsersViewModel voor EditUsersInRole view -----
        public async Task<List<RoleUsersViewModel>> CreateRoleUsersViewModel(string roleId)
        {
            IdentityRole role = await FindById(roleId);

            if (role == null)
            {
                var mdl = new List<RoleUsersViewModel>();
                
                RoleUsersViewModel roleUsersVM = new RoleUsersViewModel
                {
                    UserId = "",
                    UserName = " ",
                    IsSelected = false,
                    ErrorMessage = $"Role with Id = {roleId} cannot be found"
                };

                mdl.Add(roleUsersVM);

                return mdl;
            }

            var model = new List<RoleUsersViewModel>();

            var listUsers = accountRepository.GetUsers();

            foreach (var user in listUsers)
            {
                RoleUsersViewModel roleUsersViewModel = new RoleUsersViewModel
                {
                    UserId = user.Id,
                    UserName = user.Naam
                };

                if (await accountRepository.IsInRole(user, role.Name))
                {
                    roleUsersViewModel.IsSelected = true;
                }
                else
                {
                    roleUsersViewModel.IsSelected = false;
                }

                model.Add(roleUsersViewModel);
            }

            return model;
        }

        // ----- Aanmaken RoleClaimsViewModel voor ManageRoleClaims view -----
        public async Task<RoleClaimsViewModel> CreateRoleClaimsViewModel(string roleId)
        {
            IdentityRole role = await FindById(roleId);

            var existingRoleClaims = await repository.GetRoleClaims(role);

            var model = new RoleClaimsViewModel
            {
                RoleId = role.Id
            };

            foreach (Claim claim in ClaimsStore.AllClaims)
            {
                RoleClaim roleClaim = new RoleClaim
                {
                    ClaimType = claim.Type,
                    ClaimValue = claim.Value
                };

                // Als de rol deze claim heeft, zet IsSelected property op true en check de ckeckbox in view.
                if (existingRoleClaims.Any(c => c.Type == claim.Type))
                {
                    roleClaim.IsSelected = true;
                }
                else
                {
                    roleClaim.IsSelected = false;
                }

                model.Claims.Add(roleClaim);
            }

            return model;
        }

        // ----- Update claims van een rol -----
        public async Task<string> EditRoleClaims(RoleClaimsViewModel model)
        {
            string errorMessage = "";

            IdentityRole role = await FindById(model.RoleId);

            if (role == null)
            {
                errorMessage = $"Role with Id = {model.RoleId} cannot be found";
                return errorMessage;
            }

            var roleClaims = await repository.GetRoleClaims(role);
            
           
            foreach (Claim claim in roleClaims)
            {
                IdentityResult result = await repository.RemoveRoleClaim(role, claim);
                if (!result.Succeeded)
                {
                    errorMessage = "Cannot remove existing claim from role";
                    return errorMessage;
                }
            }

            foreach (RoleClaim claim in model.Claims)
            {
                if (claim.IsSelected)
                {
                    IdentityResult result = await repository.AddRoleClaim(role, new Claim( claim.ClaimType, claim.ClaimValue));
                    if (!result.Succeeded)
                    {
                        errorMessage = "Cannot add selected claim to role";
                        return errorMessage;
                    }
                }
            }
            
            return errorMessage;
        }

        // ----- Aanmaken ListRolesViewModel voor ListRoles view -----
        public List<ListRoleViewModel> GetListRolesViewModel()
        {
            var model = new List<ListRoleViewModel>();

            var listRoles = repository.GetRoles();

            foreach (var role in listRoles)
            {
                ListRoleViewModel listRoleViewModel = new ListRoleViewModel
                {
                    RoleId = role.Id,
                    RoleName = role.Name
                };

                model.Add(listRoleViewModel);
            }

            return model;
        }

        // ----- Updaten rol -----
        public async Task<IdentityResult> EditRole(EditRoleViewModel model)
        {
            IdentityRole role = await FindById(model.Id);

            if(role == null)
            {
                return IdentityResult.Failed();
            }

            role.Name = model.RoleName;

            IdentityResult result = await repository.EditRole(role);

            return result;
        }

        // ----- Update gebruikers in een rol -----
        public async Task<string> EditUsersInRole(List<RoleUsersViewModel> model, string roleId)
        {
            string errorMessage = "";

            IdentityRole role = await FindById(roleId);

            if (role == null)
            {
                errorMessage = $"Role with Id = {roleId} cannot be found";
                return errorMessage;
            }

            for (int i = 0; i < model.Count; i++)
            {
                var user = await accountRepository.FindById(model[i].UserId);

                IdentityResult result = null;

                if (model[i].IsSelected && !(await accountRepository.IsInRole(user, role.Name)))
                {
                    result = await accountRepository.AddToRole(user, role.Name);
                }
                else if (!model[i].IsSelected && await accountRepository.IsInRole(user, role.Name))
                {
                    result = await accountRepository.RemoveFromRole(user, role.Name);
                }
                else
                {
                    continue;
                }

                if (!result.Succeeded)
                {
                    if(i < model.Count - 1)
                    {
                        continue;
                    }
                    else
                    {
                        return errorMessage;
                    }
                }
            }

            return errorMessage;
        }

        // ----- Aanmaken ListUsersViewModel voor ListUsers view -----
        public List<ListUserViewModel> ListUsers()
        {
            var model = new List<ListUserViewModel>();

            var listUsers = accountRepository.GetUsers();

            foreach (var user in listUsers)
            {
                var listUserViewModel = new ListUserViewModel
                {
                    UserId = user.Id,
                    UserName = user.Naam
                };

                model.Add(listUserViewModel);
            }

            return model;
        }

        // ----- Aanmaken EditUserViewModel voor EditUser view -----
        public async Task<EditUserViewModel> CreateEditUserViewModel(string id)
        {
            var user = await accountRepository.FindById(id);

            if (user == null)
            {
                EditUserViewModel mdl = new EditUserViewModel
                {
                    Id = "",
                    Email = "@jojo.be",
                    UserName = " ",
                    Naam = " ",
                    XjoGebruikerCode = " ",
                    ErrorMessage = $"User with Id = {id} cannot be found"
                };

                return mdl;
            }

            var userRoles = await accountRepository.GetUserRoles(user);

            EditUserViewModel model = new EditUserViewModel
            {
                Id = user.Id,
                Email = user.Email,
                UserName = user.UserName,
                Naam = user.Naam,
                XjoGebruikerCode = user.XjoGebruikerCode,
                Actief = user.Aktief,
                ErrorMessage = "",
                Roles = userRoles
            };

            return model;
        }

        // ----- Update gebruiker -----
        public async Task<IdentityResult> EditUser(EditUserViewModel model)
        {
            var user = await accountRepository.FindById(model.Id);

            if (user == null)
            {
                return IdentityResult.Failed();
            }

            user.Email = model.Email;
            user.UserName = model.UserName;
            user.XjoGebruikerCode = model.XjoGebruikerCode;
            user.Naam = model.Naam;
            user.Aktief = model.Actief;

            IdentityResult result = await accountRepository.EditUser(user);

            return result;
        }

        // ----- Verwijderen gebruiker -----
        public async Task<IdentityResult> DeleteUser(string id)
        {
            var user = await accountRepository.FindById(id);

            if (user == null)
            {
                return IdentityResult.Failed();
            }

            IdentityResult result = await accountRepository.DeleteUser(user);

            return result;
        }

        // ----- Verwijderen rol -----
        public async Task<IdentityResult> DeleteRole(string id)
        {
            IdentityRole role = await FindById(id);

            if (role == null)
            {
                return IdentityResult.Failed();
            }

            IdentityResult result = await repository.DeleteRole(role);

            return result;
        }

        // ----- Aanmaken UserRolesViewModel voor ManageUserRoles view -----
        public async Task<List<UserRolesViewModel>> CreateUserRolesViewModel(string userId)
        {
            var user = await accountRepository.FindById(userId);

            if (user == null)
            {
                var mdl = new List<UserRolesViewModel>();

                UserRolesViewModel roleUsersVM = new UserRolesViewModel
                {
                    RoleId = "",
                    RoleName = " ",
                    IsSelected = false,
                    ErrorMessage = $"User with Id = {userId} cannot be found"
                };

                mdl.Add(roleUsersVM);

                return mdl;
            }

            var model = new List<UserRolesViewModel>();

            var listRoles = repository.GetRoles();

            foreach (var role in listRoles)
            {
                UserRolesViewModel userRolesViewModel = new UserRolesViewModel
                {
                    RoleId = role.Id,
                    RoleName = role.Name
                };

                // Als de gebruiker deze rol heeft zet IsSelected op true, anders zet op false om in view weer te geven
                if (await accountRepository.IsInRole(user, role.Name))
                {
                    userRolesViewModel.IsSelected = true;
                }
                else
                {
                    userRolesViewModel.IsSelected = false;
                }

                model.Add(userRolesViewModel);
            }

            return model;
        }

        // ----- Updaten rollen van de gebruiker -----
        public async Task<string> ManageUserRoles(List<UserRolesViewModel> model, string userId)
        {
            string errorMessage = "";

            var user = await accountRepository.FindById(userId);

            if (user == null)
            {
                errorMessage = $"User with Id = {userId} cannot be found";
                return errorMessage;
            }

            // Verwijder alle rollen van de gebruiker
            var userRoles = await accountRepository.GetUserRoles(user);
            IdentityResult result = await accountRepository.RemoveFromRoles(user, userRoles);

            if (!result.Succeeded)
            {
                errorMessage = "Cannot remove existing roles from user";
                return errorMessage;
            }

            // Koppel de geselecteerde rollen aan de gebruiker
            result = await accountRepository.AddToRoles(user,
                model.Where(x => x.IsSelected).Select(y => y.RoleName).ToList());

            if (!result.Succeeded)
            {
                errorMessage = "Cannot add selected roles to user";
                return errorMessage;
            }

            return errorMessage;
        }
    }
}
