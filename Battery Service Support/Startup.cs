using System;
using BLL;
using BLL.Interfaces;
using DAL;
using DAL.Data;
using DAL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Model;

namespace Battery_Service_Support
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration _Configuration)
        {
            Configuration = _Configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<DataContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DataConnection")));

            services.AddIdentity<ApplicationUser, IdentityRole>()
                    .AddRoles<IdentityRole>()
                    .AddEntityFrameworkStores<DataContext>()
                    .AddDefaultTokenProviders();
            services.Configure<IdentityOptions>(options =>
            {
                // Default Lockout settings
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(2);
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.AllowedForNewUsers = true;
            });

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddTransient<IExportService, ExportService>();
            services.AddTransient<IAdministrationService, AdministrationService>();
            services.AddTransient<IAdministrationRepository, AdministrationRepository>();
            services.AddTransient<IAccountService, AccountService>();
            services.AddTransient<IAccountRepository, AccountRepository>();
            services.AddTransient<IOpmerkingService, OpmerkingService>();
            services.AddTransient<IOpmerkingRepository, OpmerkingRepository>();
            services.AddTransient<IModDatumService, ModDatumService>();
            services.AddTransient<IModDatumRepository, ModDatumRepository>();
            services.AddTransient<ILeveradresService, LeveradresService>();
            services.AddTransient<ILeveradresRepository, LeveradresRepository>();
            services.AddTransient<IRelatieService, RelatieService>();
            services.AddTransient<IRelatieRepository, RelatieRepository>();
            services.AddTransient<ILandService, LandService>();
            services.AddTransient<ILandRepository, LandRepository>();
            services.AddTransient<IInstallatieService, InstallatieService>();
            services.AddTransient<IInstallatieRepository, InstallatieRepository>();
            services.AddTransient<IGemeenteService, GemeenteService>();
            services.AddTransient<IGemeenteRepository, GemeenteRepository>();
            services.AddTransient<IGebruikerTypeService, GebruikerTypeService>();
            services.AddTransient<IGebruikerTypeRepository, GebruikerTypeRepository>();
            services.AddTransient<IGebruikerService, GebruikerService>();
            services.AddTransient<IGebruikerRepository, GebruikerRepository>();
            services.AddTransient<IBatterijService, BatterijService>();
            services.AddTransient<IBatterijRepository, BatterijRepository>();
            services.AddTransient<IArtikelService, ArtikelService>();
            services.AddTransient<IArtikelRepository, ArtikelRepository>();
            services.AddMvc(config =>
            {
                var policy = new AuthorizationPolicyBuilder()
                            .RequireAuthenticatedUser()
                            .Build();
                config.Filters.Add(new AuthorizeFilter(policy));
            });

            services.AddAuthorization(options =>
            {
                options.AddPolicy("ReadCustomersPolicy", policy => policy.RequireAssertion(context =>
                    context.User.HasClaim(claim => claim.Type == "Read Customers") ||
                    context.User.IsInRole("Beheerder")));
                options.AddPolicy("EditBatteryPolicy", policy => policy.RequireAssertion(context =>
                    context.User.HasClaim(claim => claim.Type == "Edit Battery") ||
                    context.User.IsInRole("Beheerder")));
                options.AddPolicy("ListsBatteriesPolicy", policy => policy.RequireAssertion(context =>
                    context.User.HasClaim(claim => claim.Type == "Lists Batteries") ||
                    context.User.IsInRole("Beheerder")));
                options.AddPolicy("WarningBatteriesPolicy", policy => policy.RequireClaim("Warning Batteries"));
                options.AddPolicy("ListOrWarningPolicy", policy => policy.RequireAssertion(context =>
                    context.User.HasClaim(claim => claim.Type == "Lists Batteries") ||
                    context.User.HasClaim(claim => claim.Type == "Warning Batteries") ||
                    context.User.IsInRole("Beheerder")));
                options.AddPolicy("RegisterUserPolicy", policy => policy.RequireAssertion(context =>
                    context.User.HasClaim(claim => claim.Type == "Register User") ||
                    context.User.IsInRole("Beheerder")));
                options.AddPolicy("EditUserPolicy", policy => policy.RequireAssertion(context =>
                    context.User.HasClaim(claim => claim.Type == "Edit User") ||
                    context.User.IsInRole("Beheerder")));
                options.AddPolicy("DeleteUserPolicy", policy => policy.RequireAssertion(context =>
                    context.User.HasClaim(claim => claim.Type == "Delete User") ||
                    context.User.IsInRole("Beheerder")));
                options.AddPolicy("CreateRolePolicy", policy => policy.RequireAssertion(context =>
                    context.User.HasClaim(claim => claim.Type == "Create Role") ||
                    context.User.IsInRole("Beheerder")));
                options.AddPolicy("EditRolePolicy", policy => policy.RequireAssertion(context =>
                    context.User.HasClaim(claim => claim.Type == "Edit Role") ||
                    context.User.IsInRole("Beheerder")));
                options.AddPolicy("DeleteRolePolicy", policy => policy.RequireAssertion(context =>
                    context.User.HasClaim(claim => claim.Type == "Delete Role") ||
                    context.User.IsInRole("Beheerder")));
                options.AddPolicy("EditClaimsPolicy", policy => policy.RequireAssertion(context =>
                    context.User.HasClaim(claim => claim.Type == "Edit Claims") ||
                    context.User.IsInRole("Beheerder")));
                options.AddPolicy("ExportPdfPolicy", policy => policy.RequireAssertion(context =>
                    context.User.HasClaim(claim => claim.Type == "Export PDF") ||
                    context.User.IsInRole("Beheerder")));
                options.AddPolicy("ExportCsvPolicy", policy => policy.RequireAssertion(context =>
                    context.User.HasClaim(claim => claim.Type == "Export CSV") ||
                    context.User.IsInRole("Beheerder")));
                options.AddPolicy("AdminMenuPolicy", policy => policy.RequireAssertion(context =>
                    context.User.HasClaim(claim => claim.Type == "Admin Menu") ||
                    context.User.IsInRole("Beheerder")));
            });
        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseStatusCodePagesWithReExecute("/Error/{0}");
            }

            app.UseRouting();
            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Relatie}/{action=Index}/{id?}");
            });
        }
    }
}
