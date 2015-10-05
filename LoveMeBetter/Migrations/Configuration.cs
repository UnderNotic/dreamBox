using System.Data.Entity.Migrations;
using System.Runtime.InteropServices;
using System.Web;
using LoveMeBetter.Models;
using LoveMeBetter.Models.Identity;
using Microsoft.AspNet.Identity;

namespace LoveMeBetter.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //

                    
        }
    }
}
