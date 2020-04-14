using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ViewModel;

namespace BLL.Interfaces
{
    public interface IAdministrationService
    {
        Task<IdentityResult> CreateRole(CreateRoleViewModel model);
        List<ListRoleViewModel> GetRoles();
        Task<IdentityRole> FindById(string id);
        Task<List<RoleUsersViewModel>> CreateRoleUsersViewModel(string roleId);
        Task<EditRoleViewModel> CreateEditRoleViewModel(string id);
        Task<IdentityResult> EditRole(EditRoleViewModel model);
        Task<string> EditUsersInRole(List<RoleUsersViewModel> model, string roleId);
        List<ListUserViewModel> ListUsers();
        Task<EditUserViewModel> CreateEditUserViewModel(string id);
        Task<IdentityResult> EditUser(EditUserViewModel model);
        Task<IdentityResult> DeleteUser(string id);
        Task<IdentityResult> DeleteRole(string id);
        Task<List<UserRolesViewModel>> CreateUserRolesViewModel(string userId);
        Task<string> ManageUserRoles(List<UserRolesViewModel> model, string userId);
    }
}
