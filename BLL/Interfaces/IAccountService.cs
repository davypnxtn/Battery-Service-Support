using Microsoft.AspNetCore.Identity;
using Model;
using System.Threading.Tasks;
using ViewModel;

namespace BLL.Interfaces
{
    public interface IAccountService
    {
        Task<IdentityResult> Register(RegisterViewModel model);
        void Logout();
        Task<(SignInResult, bool)> Login(LoginViewModel model);
        Task<ApplicationUser> FindByName(string name);
        Task<IdentityResult> DisableUser(ApplicationUser user);
    }
}
