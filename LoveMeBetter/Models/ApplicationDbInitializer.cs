using System.Data.Entity;
using System.Linq;
using LoveMeBetter.Models.Identity;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace LoveMeBetter.Models
{
    public class ApplicationDbInitializer : CreateDatabaseIfNotExists<ApplicationDbContext>
    {
        private readonly ApplicationUserManager _applicationUserManager;

        public ApplicationDbInitializer(ApplicationUserManager applicationUserManager)
        {
            _applicationUserManager = applicationUserManager;
        }

        protected override void Seed(ApplicationDbContext context)
        {
            InitializeIdentityForEf(context);
            base.Seed(context);
        }

        private async void InitializeIdentityForEf(ApplicationDbContext db)
        {
            if (!db.Users.Any())
            {
                var roleStore = new RoleStore<IdentityRole>(db);
                var roleManager = new RoleManager<IdentityRole>(roleStore);
                // Add missing roles
                var role = roleManager.FindByName("Admin");
                if (role == null)
                {
                    role = new IdentityRole("Admin");
                    roleManager.Create(role);
                }

                // InitCreate test users
                var user = _applicationUserManager.FindByName("admin");
                if (user == null)
                {
                    var adminUser = ApplicationUser.MakeAdminUser();

                    adminUser.UserName = "Admin";
                    adminUser.Email = "admin@admin.com";
                    adminUser.EmailConfirmed = true;
                    await _applicationUserManager.CreateAsync(adminUser, "admin123");
                    await _applicationUserManager.SetLockoutEnabledAsync(adminUser.Id, true);
                    await _applicationUserManager.AddToRoleAsync(adminUser.Id, "Admin");
                }
            }
        }
    }
}