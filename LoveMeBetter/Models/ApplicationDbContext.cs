using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using Autofac;
using LoveMeBetter.Models.Identity;
using LoveMeBetter.Models.Order;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;

namespace LoveMeBetter.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Order.Order> Orders { get; set; }
        public DbSet<OrderDetails> OrdersDetails { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<RandomizedProductCategory> RandomizedProductCategories { get; set; }

        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
            InitializeDatabase();
        }

        public void InitializeDatabase()
        {
            Database.SetInitializer(new ApplicationDbInitializer());
        }
    }
}