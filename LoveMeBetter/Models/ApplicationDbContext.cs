using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using LoveMeBetter.Models.Identity;
using LoveMeBetter.Models.Order;
using Microsoft.AspNet.Identity.EntityFramework;

namespace LoveMeBetter.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        private readonly ApplicationDbInitializer _applicationDbInitializer;
        public DbSet<Order.Order> Orders { get; set; }
        public DbSet<OrderDetails> OrdersDetails { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<RandomizedProductCategory> RandomizedProductCategories { get; set; } 

        public ApplicationDbContext(ApplicationDbInitializer applicationDbInitializer)
            : base("DefaultConnection", throwIfV1Schema: false)
        {
            _applicationDbInitializer = applicationDbInitializer;
            InitializeDatabase();
        }

        public void InitializeDatabase()
        {
            Database.SetInitializer(_applicationDbInitializer);
        }
    }
}