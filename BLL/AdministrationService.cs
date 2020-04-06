using BLL.Interfaces;
using DAL.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
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

            foreach (var user in listUsers)
            {
                if(await accountRepository.IsInRole(user, role.Name))
                {
                    model.Users.Add(user.UserName);
                }
            }

            return model;
        }

        public async Task<List<UserRoleViewModel>> CreateUserRoleViewModel(string roleId)
        {
            IdentityRole role = await FindById(roleId);

            if (role == null)
            {
                var mdl = new List<UserRoleViewModel>();
                
                UserRoleViewModel userRoleVM = new UserRoleViewModel
                {
                    UserId = "",
                    UserName = " ",
                    IsSelected = false,
                    ErrorMessage = $"Role with Id = {roleId} cannot be found"
                };

                mdl.Add(userRoleVM);

                return mdl;
            }

            var model = new List<UserRoleViewModel>();

            var listUsers = accountRepository.GetUsers();

            foreach (var user in listUsers)
            {
                UserRoleViewModel userRoleViewModel = new UserRoleViewModel
                {
                    UserId = user.Id,
                    UserName = user.UserName
                };

                if (await accountRepository.IsInRole(user, role.Name))
                {
                    userRoleViewModel.IsSelected = true;
                }
                else
                {
                    userRoleViewModel.IsSelected = false;
                }

                model.Add(userRoleViewModel);
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

        public async Task<string> EditUsersInRole(List<UserRoleViewModel> model, string roleId)
        {
            string errorMessage = "";

            IdentityRole role = await FindById(roleId);

            if (role == null)
            {
                errorMessage = $"Role with Id = {roleId} cannot be found";
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
                    UserName = user.UserName
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

            IdentityResult result = await accountRepository.EditUser(user);
            return result;
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
