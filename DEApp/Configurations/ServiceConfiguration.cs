using DEApp.Services;
using DEApp.Interfaces;
using DEApp.Models;
using DEApp.Repositories;

namespace DEApp.Configuration
{
    public static class ServiceConfiguration
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {
            // Register services and repositories

            services.AddScoped<IApplicantService, ApplicantService>();
            services.AddScoped<IApplicantRepository, ApplicantRepository>();
            
            //Vendor
            services.AddScoped<IVendorService, VendorService>();
            services.AddScoped<IVendorRepository<int, Vendor>, VendorRepository>();

            //Users
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserRepository<string, User>, UserRepository>();
            services.AddScoped<ITokenService, TokenService>();

            //Loans
            services.AddScoped<ILoanService, LoanService>();
            services.AddScoped<ILoanRepository<int, Loan>, LoanRepository>();

            //ProfileSettings
            services.AddScoped<IProfilesettingService, ProfilesettingService>();
            services.AddScoped<IProfilesettingRepository<int, ProfileSetting>, ProfilesettingRepository>();
            services.AddScoped<IRoleRepository<string, Role>, RoleRepository>();




        }
    }
}