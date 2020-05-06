using BLL.Interfaces;
using DAL.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<IdentityResult> CreateRole(CreateRoleViewModel model)
        {
            IdentityRole identityRole = new IdentityRole
            {
                Name = model.RoleName
            };

            IdentityResult result = await repository.CreateRole(identityRole);
            
            return result;
        }

        public async Task<IdentityRole> FindById(string id)
        {
            return await repository.FindById(id);
        }

        public async Task<EditRoleViewModel> CreateEditRoleViewModel(string id)
        {
            //var (role, errorMessage) = await RoleCheck(id);
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
            var roleClaims = await repository.GetClaims(role);

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
                    UserName = user.UserName
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

        public List<ListRoleViewModel> GetRoles()
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

        public async Task<IdentityResult> EditRole(EditRoleViewModel model)
        {
            //var (role, errorMessage) = await RoleCheck(model.Id);
            IdentityRole role = await FindById(model.Id);

            if(role == null)
            {
                return IdentityResult.Failed();
            }

            role.Name = model.RoleName;

            IdentityResult result = await repository.EditRole(role);

            return result;
        }

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

                if (result.Succeeded)
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

        public async Task<string> ManageUserRoles(List<UserRolesViewModel> model, string userId)
        {
            string errorMessage = "";

            var user = await accountRepository.FindById(userId);

            if (user == null)
            {
                errorMessage = $"User with Id = {userId} cannot be found";
                return errorMessage;
            }

            var roles = await accountRepository.GetUserRoles(user);
            IdentityResult result = await accountRepository.RemoveFromRoles(user, roles);

            if (!result.Succeeded)
            {
                errorMessage = "Cannot remove existing roles from user";
                return errorMessage;
            }

            result = await accountRepository.AddToRoles(user,
                model.Where(x => x.IsSelected).Select(y => y.RoleName).ToList());

            if (!result.Succeeded)
            {
                errorMessage = "Cannot add selected roles to user";
                return errorMessage;
            }

            return errorMessage;
        }

        //private async Task<(IdentityRole, string)> RoleCheck(string id)
        //{
        //    IdentityRole role = await FindById(id);

        //    if(role == null)
        //    {
        //        //role.Id = "";
        //        //role.Name = " ";
        //        string errorMessage = $"Rol with Id = {id} cannot be found";
        //        return (role, errorMessage);
        //    }

        //    string emptyMessage = "";
        //    return (role, emptyMessage);
        //}
    }
}
