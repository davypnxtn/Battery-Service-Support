using DAL.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class AdministrationRepository : IAdministrationRepository
    {
        private readonly RoleManager<IdentityRole> roleManager;

        public AdministrationRepository(RoleManager<IdentityRole> _roleManager)
        {
            roleManager = _roleManager;
        }

        // ----- Aanmaken nieuwe rol -----
        public async Task<IdentityResult> CreateRole(IdentityRole identityRole)
        {
            try
            {
                return await roleManager.CreateAsync(identityRole);
            }
            catch (Exception)
            {
                throw;
            }
        }

        // ----- Zoek rol op rol id -----
        public async Task<IdentityRole> FindById(string id)
        {
            return await roleManager.FindByIdAsync(id);
        }

        // ----- Zoek rol op naam -----
        public async Task<IdentityRole> FindByName(string name)
        {
            return await roleManager.FindByNameAsync(name);
        }

        // ----- Ophalen alle rollen -----
        public List<IdentityRole> GetRoles()
        {
            return roleManager.Roles.ToList();
        }

        // ----- Wijzigen rol -----
        public async Task<IdentityResult> EditRole(IdentityRole role)
        {
            try
            {
                return await roleManager.UpdateAsync(role);
            }
            catch (Exception)
            {
                throw;
            }
        }

        // ----- Verwijderen rol -----
        public async Task<IdentityResult> DeleteRole(IdentityRole role)
        {
            try
            {
                return await roleManager.DeleteAsync(role);
            }
            catch 
            {
                throw new Exception("Exception while deleting Role, there are Users assigned to this Role");
            }
        }

        // ----- Opvragen alle claims van een rol -----
        public async Task<IList<Claim>> GetRoleClaims(IdentityRole role)
        {
            return await roleManager.GetClaimsAsync(role);
        }

        // ----- Verwijderen claim van een rol -----
        public async Task<IdentityResult> RemoveRoleClaim(IdentityRole role, Claim claim)
        {
            try
            {
                return await roleManager.RemoveClaimAsync(role, claim);
            }
            catch (Exception)
            {
                throw;
            }
        }

        // ----- Toevoegen claim aan een rol -----
        public async Task<IdentityResult> AddRoleClaim(IdentityRole role, Claim claim)
        {
            try
            {
                return await roleManager.AddClaimAsync(role, claim);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
