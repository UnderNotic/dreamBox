using System.Data.Entity;
using Autofac;
using LoveMeBetter.Models.Identity;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace LoveMeBetter.Models
{
    public class ApplicationDbInitializer : CreateDatabaseIfNotExists<ApplicationDbContext>
    {

        protected override void Seed(ApplicationDbContext context)
        {
            InitializeIdentityForEf(context);
            base.Seed(context);
        }

        private void InitializeIdentityForEf(ApplicationDbContext db)
        {
            var applicationUserManager = AutofacBootstrapper.GetContainer().Resolve<ApplicationUserManager>();
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
            var user = applicationUserManager.FindByName("admin");
            if (user == null)
            {
                var adminUser = ApplicationUser.MakeAdminUser();

                adminUser.UserName = "Admin";
                adminUser.Email = "admin@admin.com";
                var result = applicationUserManager.Create(adminUser, "admin123");
                if (result.Succeeded)
                {
                applicationUserManager.SetLockoutEnabled(adminUser.Id, true);
                applicationUserManager.AddToRole(adminUser.Id, "Admin");
                }
            }
        }
    }
}