using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace ViewModel
{
    public static class ClaimsStore
    {
        public static List<Claim> AllClaims = new List<Claim>()
        {
            new Claim("Read Customers", "Lezen Relaties"),
            new Claim("Edit Battery", "Edit Batterij"),
            new Claim("Create Role", "Aanmaken Rol"),
            new Claim("Edit Role", "Edit Rol"),
            new Claim("Delete Role", "Verwijderen Rol"),
            new Claim("Register User", "Registreer Gebruiker"),
            new Claim("Edit User", "Edit Gebruiker"),
            new Claim("Delete User", "Verwijder Gebruiker"),
            new Claim("Lists Batteries", "Lijsten Batterijen"),
            new Claim("Export PDF", "Exporteer PDF"),
            new Claim("Export CSV", "Exporteer CSV"),
            new Claim("Edit Claims", "Edit Machtigingen"),
            new Claim("Admin Menu", "Admin Menu")
        };
    }
}
